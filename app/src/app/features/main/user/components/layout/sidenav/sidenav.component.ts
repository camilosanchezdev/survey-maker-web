import { Component, OnInit } from '@angular/core'

export interface Tile {
    color: string
    cols: number
    rows: number
    text: string
}

@Component({
    selector: 'app-sidenav',
    templateUrl: './sidenav.component.html',
    styleUrls: ['./sidenav.component.scss'],
})
export class SidenavComponent implements OnInit {
    tiles: Tile[] = [
        { text: 'Two', cols: 1, rows: 5, color: 'lightgreen' },
        { text: 'One', cols: 3, rows: 5, color: 'lightblue' },
    ]
    constructor() {}

    ngOnInit(): void {}
}
