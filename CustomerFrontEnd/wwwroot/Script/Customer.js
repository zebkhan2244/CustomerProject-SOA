$(document).ready(function () {
    getAllCustomer();
    

});




//select All Customer
function SaveCustomer() {
    debugger;
    //var url = "localhost:44307/api/Customer/Add";
    var objCustomer = {};
    objCustomer.Name = $("#Name").val();
    objCustomer.Address = $("#Address").val();
    objCustomer.City = $("#City").val();
    objCustomer.State = $("#State").val();
    objCustomer.CustomerTypeId = $("#CustomerType").val();
    objCustomer.Zip = $("#Zip").val();
    objCustomer.Description = $("#Description").val();
    if (objCustomer) {
        $.ajax({
            url: "https://localhost:44307/api/Customer/Add",
            contentType: "application/json; charset=utf-8", 
            dataType:"json",
            data: JSON.stringify(objCustomer),
            accepts: {
                json: "application/json, text/javascript"
            },
            type:"Post",
            success: function (data) {
                alert("Saved successfully");
                 clearTextBox();
                $('#myModal').modal('hide');
                $(".modal-backdrop").remove();
                getAllCustomer();

               
            },
            error: function (jqXHR, textStatus) {
                //getAllCustomer();
                alert("Request failed: " + textStatus);
            }
        });
    }
};
function getAllCustomer() {

    $.ajax({
        url: "https://localhost:44307/api/Customer/GetAll",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "Get",
        success: function (response) {
            debugger;
            var html = '';
           
            var rownum = 0;
            $.each(response.resultJSON, function parseJSON(i, item) {
                rownum = rownum + 1;
                html += '<tr>'; 
                html += '<td hidden>' + item.id + '</td>';
                html += '<td>' + parseInt(rownum) + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.address + '</td>';
                html += '<td>' + item.city + '</td>';
                html += '<td>' + item.state + '</td>';
                html += '<td>' + item.zip + '</td>';
                html += '<td><button type="button" class="btn btn-primary btn-sm"  onclick="return getbyID(' + item.id + ')"><i class="fa fa-edit"></i> Edit</button> | <button type="button" class="btn btn-danger btn-sm"  onclick="return Delele(' + item.id + ')"><i class="fa fa-trash"></i> Delete</button></td>';
                html += '</tr>';
            });
            $('td:nth-child(1)').hide();
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });


}
function getbyID(CusId) {
    debugger;
    $('#Name').css('border-color', 'lightgrey');
    $('#City').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#CustomerType').css('border-color', 'lightgrey');
    $('#Description').css('border-color', 'lightgrey');
    $('#Zip').css('border-color', 'lightgrey');
    $.ajax({
        url: "https://localhost:44307/api/Customer/GetById/" + CusId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            debugger;
            console.log(response);
            console.log(response.resultJSON);
            var data = response.resultJSON;
            var myname = data.name;

            $("#Name").val(data.name);
            $('#CusID').val(data.id);
            $('#City').val(data.city);
           
            var valid = data.customerTypeId;
            if (valid == 1) {
                $('#CustomerType option:contains("Permanant")').prop('selected', true);
            }
            else {
                $('#CustomerType option:contains("Temprory")').prop('selected', true);
            }
            
            $('#State').val(data.state);
            $('#Address').val(data.address);
            $('#Zip').val(data.zip);
            $('#Description').val(data.description);


                $('#myModal').modal('show');
                $('#btnUpdate').show();
            $('#btnAdd').hide();

          
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//function for updating employee's record  
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var objCustomer = {};
    objCustomer.Id = $('#CusID').val();
    objCustomer.Name = $("#Name").val();
    objCustomer.Address = $("#Address").val();
    objCustomer.City = $("#City").val();
    objCustomer.State = $("#State").val();
    objCustomer.CustomerTypeId = $("#CustomerType").val();
    objCustomer.Zip = $("#Zip").val();
    objCustomer.Description = $("#Description").val();
    $.ajax({
        url: "https://localhost:44307/api/Customer/Update",
        data: JSON.stringify(objCustomer),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            getAllCustomer();
            $('#myModal').modal('hide');
            clearTextBox()
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#City').val().trim() == "") {
        $('#City').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#City').css('border-color', 'lightgrey');
    }
    if ($('#State').val().trim() == "") {
        $('#State').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#State').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }
    if ($('#Description').val().trim() == "") {
        $('#Description').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Description').css('border-color', 'lightgrey');
    }
    if ($('#CustomerType').val().trim() == "") {
        $('#CustomerType').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CustomerType').css('border-color', 'lightgrey');
    }
    if ($('#Zip').val().trim() == "") {
        $('#Zip').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Zip').css('border-color', 'lightgrey');
    }
    return isValid;
}
function Delele(ID) {
   /* alert(ID);*/
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "https://localhost:44307/api/Customer/Delete/",
            type: "get",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: { "id": ID },
            success: function (result) {
                getAllCustomer();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function clearTextBox() {
    $('#Name').val("");
    $('#City').val("");
    $('#State').val("");
    $('#Address').val("");
    $('#CustomerType').val("");
    $('#Description').val("");
    $('#Zip').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#City').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#CustomerType').css('border-color', 'lightgrey');
    $('#Description').css('border-color', 'lightgrey');
    $('#Zip').css('border-color', 'lightgrey');
}