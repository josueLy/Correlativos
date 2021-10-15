// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$("#lblValidador").hide();
$("#lblValidadorMonto").hide();
$("#lblValidadorDni").hide();


//$("#frmSalir").submit(function (event) {
//    alert("submiteado");
   
//    window.location.replace("http://stackoverflow.com");

//});

$("#frmcorrelativo").submit(function (event) {


    if (($("#cmbTipoDocumento").val() == 6 || $("#cmbTipoDocumento").val() == 1) && ($("#txtDescripcion").val() == "") && $("#txtDni").val() != "" && $("#txtNombre").val() != "")
    {
        $("#lblValidador").show();
        event.preventDefault();
    }
    var monto = parseInt($("#txtMonto").val());
   
    if (($("#txtMonto").val() == "" || monto <= 0) && $("#cmbTipoDocumento").val() == 1 && $("#txtDni").val() != "" && $("#txtNombre").val() != "") {
        $("#lblValidadorMonto").show();
        event.preventDefault();
    }

   

    if ($("#txtDni").val()=="")
    {
        $("#lblValidadorDni").show();
        event.preventDefault();
    }
});




    

   
