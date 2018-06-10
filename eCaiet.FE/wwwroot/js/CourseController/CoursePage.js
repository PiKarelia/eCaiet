var Delta = Quill.import('delta');

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
    function (index, value) {
        var change = new Delta();
        var quillId = $(value).attr('id');
        var quill = new Quill("#" + quillId, options);
        // Store accumulated changes
        quill.on('text-change', function (delta) {
            //console.log(quill.root.innerHTML);
            //TODO set time limit for this coz requests are too often
            //change = change.compose(delta);
            $.ajax({
                url: "/Course/EditFile",
                type: 'POST',
                data: {
                    Guid: quillId.split('_')[1],
                    Data: quill.root.innerHTML,
                    CourseGuid: $("#course-guid").val()
                },
                //global: false,
                success: function (data) {
                    //alert("Fișier adăugat cu succes");
                },
                error: function (data) {
                    //alert("EROARE! Fișierul nu s-a salvat");
                }
            });
        });
    });
/*
// Save periodically
setInterval(function () {
    if (change.length() > 0) {
        console.log('Saving changes', change);
        /* 
        Send partial changes
        $.post('/your-endpoint', { 
          partial: JSON.stringify(change) 
        });
        
        Send entire document
        $.post('/your-endpoint', { 
          doc: JSON.stringify(quill.getContents())
        });
        #1#
        change = new Delta();
    }
}, 5 * 1000);*/

// Check for unsaved data
/*window.onbeforeunload = function () {
    if (change.length() > 0) {
        return 'There are unsaved changes. Are you sure you want to leave?';
    }
}*/



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
