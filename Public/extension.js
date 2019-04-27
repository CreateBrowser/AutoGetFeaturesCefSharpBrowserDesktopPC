(function () {
    absolutePath = function (href) {
        var link = document.createElement("a");
        link.href = href;
        return (link.protocol + "//" + link.host + link.pathname + link.search + link.hash);
}
    showModalDialog = function (url, arg, opt) {
        url = url || ''; //URL of a dialog
        arg = arg || null; //arguments to a dialog
        opt = opt || 'dialogWidth:300px;dialogHeight:200px'; //options: dialogTop;dialogLeft;dialogWidth;dialogHeight or CSS styles
        var caller = showModalDialog.caller.toString();
        var dialog = document.body.appendChild(document.createElement('dialog'));
        dialog.setAttribute('style', opt.replace(/dialog/gi, ''));
        dialog.innerHTML = '<a href="#" id="dialog-close" style="position: absolute; top: 0; right: 4px; font-size: 20px; color: #000; text-decoration: none; outline: none;">&times;</a><iframe id="dialog-body" name="dialog-body" src="' + absolutePath(url) + '" style="border: 0; width: 100%; height: 100%;"></iframe>';
    //document.getElementById('dialog-body').contentWindow.dialogArguments = arg;
        document.getElementById('dialog-close').addEventListener('click', function (e) {
            e.preventDefault();
            dialog.close();
});
        document.getElementById('dialog-body').addEventListener('load',     function (e) {
            this.style.height = this.contentWindow.document.body.scrollHeight + 'px';
            this.style.width = this.contentWindow.document.body.scrollWidth + 'px';
            this.contentWindow.close = function () {
                dialog.close();
};
            this.contentWindow.dialogArguments = arg;
            this.window = this.contentWindow;
});

        dialog.showModal();
    //if using yield
        if (caller.indexOf('yield') >= 0) {
            return new Promise(function (resolve, reject) {
                dialog.addEventListener('close', function () {
                    var returnValue = document.getElementById('dialog-    body').contentWindow.returnValue;
                    document.body.removeChild(dialog);
                    resolve(returnValue);
});
});
}
    //if using eval
        var isNext = false;
        var nextStmts = caller.split('\n').filter(function (stmt) {
            if (isNext || stmt.indexOf('showModalDialog(') >= 0)
                return isNext = true;
            return false;
});

        dialog.addEventListener('close', function () {
            var returnValue = document.getElementById('dialog-body').contentWindow.returnValue;
            document.body.removeChild(dialog);
    //nextStmts[0] = nextStmts[0].replace(/(window\.)?showModalDialog\(.*\)/g, JSON.stringify(returnValue));
    //eval('{\n' + nextStmts.join('\n'));
});
        throw 'Execution stopped until showModalDialog is closed';
};
})();