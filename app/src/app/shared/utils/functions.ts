export function downloadExcel(response, fileName) {
    var link = document.createElement('a')
    link.href = window.URL.createObjectURL(response)
    link.download = fileName
    link.click()
}
