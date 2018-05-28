var options = {
    modules: {
        toolbar: [
            [{ header: [1, 2, false] }],
            ['bold', 'italic', 'underline', 'strike'],
            ['image', 'code-block'],
            ['blockquote', 'indent', 'list', 'align', 'direction', 'formula']
        ]
    },
    placeholder: 'Scrie ceva aici...',
    readOnly: false,
    theme: 'snow'
};
var editors = $("div[id^='editor_']");
$.each(editors,
    function(index, value) {
        var quill = new Quill("#"+$(value).attr('id'), options);
    });



$(document).ready(function() {

    $("#newFileFormSubmit").click(function () {
        var data = $('#newFileForm').serializeArray();
        
        $.ajax({
            url: "/Course/AddFile",
            type: 'POST',
            data: data,
            //global: false,
            success: function (data) {
                alert("Fișier adăugat cu succes");
            },
            error: function (data) {
                alert("EROARE! Fișierul nu s-a salvat"); 
            }
        });

    });

});
