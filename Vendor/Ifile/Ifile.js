(function ($) {
    $.fn.IFile = function () {
        //alert('hello world');

        $('input[type=file].IFile').change(function () {
            var t = $(this).val();
            var nf = t.substr(12, t.length);
            if (nf.length > 55) {
                nf = nf.substr(0, 55) + " ...";
                console.log(nf);
                console.log(nf.length);
            }
            var labelText = 'Archivo : ' + nf;
            $(this).prev('label').text(labelText);
        });
        return this;
    };
})(jQuery);