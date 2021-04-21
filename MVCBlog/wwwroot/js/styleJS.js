
function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}

// Close the dropdown menu if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}

function myFunction(id) {
    var popup = document.getElementById(id);
    popup.classList.toggle("show");
}

function fileCheck(obj) {
    var fileExtension = ['jpeg', 'jpg', 'png', 'gif', 'bmp'];
    if ($.inArray($(obj).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
        alert("Only '.jpeg','.jpg', '.png', '.gif', '.bmp' formats are allowed.");
    }
}

$(document).ready(function () {
    $('#summernote').summernote({
        height: 300,                 // set editor height
        minHeight: null,             // set minimum height of editor
        maxHeight: null,             // set maximum height of editor
        focus: true                  // set focus to editable area after initializing summernote
    });
});

$(document).ready(function () {
    $('.summernote').summernote({
        height: 300,                 // set editor height
        minHeight: null,             // set minimum height of editor
        maxHeight: null,             // set maximum height of editor
        focus: true                  // set focus to editable area after initializing summernote
    });
});

$(document).ready(function () {

});

$("#memberImage").change(function () {
    var files = event.target.files;

    $("#imgViewerMember").attr("src", window.URL.createObjectURL(files[0]));
});

$("#btnSaveImage").click(function () {
    var files = $("#memberImage").prop("files");
    var formData = new FormData();
    for (var i = 0; i < files.length; i++) {
        formData.append("file", files[i]);
    }

    

    $.ajax({
        type: "POST",
        url: "/Member/SaveImage",
        data: formData,
        processData: false,
        contentType: false,
        success: function () {
            alert("Saved");
        },
        error: function (data) {
            console.log("Failed")
        }
    });
});