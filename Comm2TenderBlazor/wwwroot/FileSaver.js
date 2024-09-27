window.saveAsFile = function (fileName, fileContent) {
    var link = document.createElement('a');
    link.download = fileName;
    link.href = "data:application/octet-stream;base64," + fileContent;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};