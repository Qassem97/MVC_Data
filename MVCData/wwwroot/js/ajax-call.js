function AjaxPost(html_id, url) {
    $.post(url,
        {

        },
        function (data, status) {
            if (status === 'success') {
                $('#' + html_id).replaceWith(data);
            }
            else if (status === 'notfound') {
                $('#' + html_id).replaceWith('');
                alert("Your list is old, please refrech.");
            }
            else if (status === 'badrequest') {
                alert("Your list is corrupt, please refrech.");
            }
            else {
                console.log('error:' + status);
            }
        }
    );
}
function AjaxPostPersonForm(html_id, url) {
    
}
function AjaxGet(html_id, url) {
    $.get(url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}


$('#addPersonForms').submit(function (event) {
    event.preventDefault();
    console.log('tessss');
    $.post("/Home/SingUp",
        {
            Name: $("#Person_Name").val(), //Reading text box values using Jquery   
            Number: $("#Person_Number").val(),
            City: $("#Person_City").val()
        },
        function (data, status) {
            if (status === 'success') {
                $('#personListId').replaceWith(data);
            }
            else if (status === 'badrequest') {
                alert("Your list is corrupt, please refrech.");
            }
            else {
                console.log('error:' + status);
            }
        }
    );
}); 







//$('#searchPeople').submit(function (event) {
//    event.preventDefault();
//    console.log('tessss');
//    $.post("/Home/Index",
//        {
//            Name: $("#Person_Name").val(), //Reading text box values using Jquery   
//            Number: $("#Person_Number").val(),
//            City: $("#Person_City").val()
//        },
//        function (data, status) {
//            if (status === 'success') {
//                $('#personListId').replaceWith(data);
//            }
//            else if (status === 'badrequest') {
//                alert("Your list is corrupt, please refrech.");
//            }
//            else {
//                console.log('error:' + status);
//            }
//        }
//    );
//}); 

