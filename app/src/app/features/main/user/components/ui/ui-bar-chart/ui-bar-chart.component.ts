import {
    AfterViewInit,
    ChangeDetectionStrategy,
    Component,
    ElementRef,
    Inject,
    Input,
    NgZone,
    OnChanges,
    OnDestroy,
    OnInit,
    PLATFORM_ID,
    SimpleChanges,
    ViewChild,
} from '@angular/core'
import * as am5 from '@amcharts/amcharts5'
import * as am5xy from '@amcharts/amcharts5/xy'
import am5themes_Animated from '@amcharts/amcharts5/themes/Animated'
import { isPlatformBrowser } from '@angular/common'
@Component({
    selector: 'ui-bar-chart',
    templateUrl: './ui-bar-chart.component.html',
    styleUrls: ['./ui-bar-chart.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UiBarChartComponent implements OnDestroy, AfterViewInit, OnChanges {
    @Input() data: any
    @ViewChild('chart') chart: ElementRef
    private root: am5.Root

    constructor(@Inject(PLATFORM_ID) private platformId, private zone: NgZone) {}
    ngOnChanges(changes: SimpleChanges): void {
        if (changes.data && this.data && this.chart) {
            this.setChart()
        }
    }
    setChart(): void {
        this.browserOnly(() => {
            //   import am4themes_https://cdn.amcharts.com/lib/5/Animated from "@amcharts/amcharts4/themes/https://cdn.amcharts.com/lib/5/Animated";

            /* Chart code */
            // Create root element
            // https://www.amcharts.com/docs/v5/getting-started/#Root_element
            // let root = am5.Root.new(this.chart.nativeElement)
            let root = am5.Root.new(this.chart.nativeElement)

            // Set themes
            // https://www.amcharts.com/docs/v5/concepts/themes/
            root.setThemes([am5themes_Animated.new(root)])

            // Create chart
            // https://www.amcharts.com/docs/v5/charts/xy-chart/
            let chart = root.container.children.push(
                am5xy.XYChart.new(root, {
                    panX: true,
                    panY: true,
                    wheelX: 'panX',
                    wheelY: 'zoomX',
                    pinchZoomX: true,
                })
            )

            // Add cursor
            // https://www.amcharts.com/docs/v5/charts/xy-chart/cursor/
            let cursor = chart.set('cursor', am5xy.XYCursor.new(root, {}))
            cursor.lineY.set('visible', false)

            // Create axes
            // https://www.amcharts.com/docs/v5/charts/xy-chart/axes/
            let xRenderer = am5xy.AxisRendererX.new(root, { minGridDistance: 30 })
            xRenderer.labels.template.setAll({
                rotation: 0,
                centerY: am5.p50,
                centerX: am5.p100,
                paddingRight: 15,
            })

            let xAxis = chart.xAxes.push(
                am5xy.CategoryAxis.new(root, {
                    maxDeviation: 0.3,
                    categoryField: 'answerName',
                    renderer: xRenderer,
                    tooltip: am5.Tooltip.new(root, {}),
                })
            )

            let yAxis = chart.yAxes.push(
                am5xy.ValueAxis.new(root, {
                    maxDeviation: 0.3,
                    renderer: am5xy.AxisRendererY.new(root, {}),
                })
            )

            // Create series
            // https://www.amcharts.com/docs/v5/charts/xy-chart/series/
            let series = chart.series.push(
                am5xy.ColumnSeries.new(root, {
                    name: 'Series 1',
                    xAxis: xAxis,
                    yAxis: yAxis,
                    valueYField: 'quantity',
                    sequencedInterpolation: true,
                    categoryXField: 'answerName',
                    tooltip: am5.Tooltip.new(root, {
                        labelText: '{valueY}',
                    }),
                })
            )

            series.columns.template.setAll({ cornerRadiusTL: 5, cornerRadiusTR: 5 })
            series.columns.template.adapters.add('fill', function (fill, target) {
                return chart.get('colors').getIndex(series.columns.indexOf(target))
            })

            series.columns.template.adapters.add('stroke', function (stroke, target) {
                return chart.get('colors').getIndex(series.columns.indexOf(target))
            })

            // Set data
            xAxis.data.setAll(this.data)
            series.data.setAll(this.data)

            // Make stuff animate on load
            // https://www.amcharts.com/docs/v5/concepts/animations/
            series.appear(1000)
            chart.appear(1000, 100)
        })
    }
    // Run the function only in the browser
    browserOnly(f: () => void) {
        if (isPlatformBrowser(this.platformId)) {
            this.zone.runOutsideAngular(() => {
                f()
            })
        }
    }

    ngAfterViewInit(): void {
        if (this.data) {
            this.setChart()
        }
    }

    ngOnDestroy() {
        // Clean up chart when the component is removed
        this.browserOnly(() => {
            if (this.root) {
                this.root.dispose()
            }
        })
    }
}
