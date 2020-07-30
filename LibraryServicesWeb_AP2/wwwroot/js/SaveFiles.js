function saveAsFile(fileName, bytesBase64) {
    var link = document.createElement("a");
    link.download = fileName;

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

}