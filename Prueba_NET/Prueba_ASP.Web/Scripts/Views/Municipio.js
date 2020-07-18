
$(document).ready(function () {
    loadDataTable();
    loadRegion();
});

function loadRegion() {
    $.ajax({
        url: "/Municipio/listarRegion/",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var clasificacion = $("#cbxRegion");
            var datos = data.data;
            $(datos).each(function (i, v) {
                clasificacion.append('<option value="' + v.CodigoR + '">' + v.Nombre + '</option>');
            });
        },
        error: function () {
            console.log('error');
        }
    });
}
    
function GetData(tbody, table) {
    $(tbody).on('click', '#btnEditar', function () {
        var objDatos = table.row($(this).parents('tr')).data();
        $('#codigo').val(objDatos.Codigo_Municipio);
        $('#municipio').val(objDatos.Nombre_Municipio);
        $('#estado').val(objDatos.Estado);
        $('#cbxRegion').val(objDatos.Codigo_Region);
        $("#codigo").attr("readonly", "readonly");
    });
}

function loadDataTable() {
    $.ajax({
        url: "/Municipio/listar",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Codigo_Municipio + '</td>';
                html += '<td>' + item.Nombre_Municipio + '</td>';
                html += '<td>' + item.Estado + '</td>';
                html += '<td>' + item.Codigo_Region + '</td>';
                html += '<td>' + item.Nombre_Region + '</td>';
                html += '<td><a href="#" class="glyphicon glyphicon-pencil" id="btnEditar"></a> | <a href="#" class="glyphicon  glyphicon-trash" class="btn btn-danger" onclick="Delele(' + item.Codigo_Municipio + ' ' + item.Codigo_Region + ')"></a></td>';
                html += '</tr>';
                //onclick="return consultarPorId(' + item.Codigo_Municipio + ')"
            });
            $('.tbody').html(html);
            GetData("#datatable", html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Actualizar() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}
    var actMunicipio = {
        Codigo_Municipio : $('#codigo').val(),
        Nombre_Municipio: $('#municipio').val(),
        Estado: $('#estado').val(),
    };
    $.ajax({
        url: "/Principal/Actualizar",
        data: JSON.stringify(actMunicipio),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDataTable();
            $('#codigo').val("");
            $('#municipio').val("");
            $('#estado').val("");
            $('#cbxRegion').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function consultarPorId(cod_M) {
    $('#codigo').css('border-color', 'lightgrey');
    $('#municipio').css('border-color', 'lightgrey');
    $('#estado').css('border-color', 'lightgrey');
    $('#cbxRegion').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Municipio/consultarPorId/" + cod_M,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#codigo').val(result.Codigo_Municipio);
            $('#municipio').val(result.Nombre_Municipio);
            $('#estado').val(result.Estado);
            $('#cbxRegion').val(result.Codigo_Region);
            $("#codigo").attr("readonly", "readonly");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

$('#btnGuardar').click(function () {
    var res = validacionMunicipio();
    if (res == false) {
        return false;
    }
    municipio = {};
    municipio.Codigo_Municipio = $('#codigo').val();
    municipio.Nombre_Municipio = $('#municipio').val();
    municipio.Estado = $('#estado').val();
    municipio.Codigo_Region = $('#cbxRegion').val();
    
    $.ajax({
        url: '/Municipio/guardarMunicipio',
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: municipio,
        success: function (data) {
            var result = data.data;
            if (result.Succes) {
                loadDataTable();
            } else {
              //ingresar codigo      
            }
            $('#codigo').val('');
            $('#municipio').val('');
            $('#estado').val('');
            $('#cbxRegion').val('');
            $("#codigo").removeAttr("readonly");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    }); 
});

   
  
function validacionMunicipio() {
    var Valido = true;
    if ($('#codigo').val().trim() == "") {
        $('#codigo').css('border-color', 'Red');
        Valido = false;
    }
    else {
        $('#codigo').css('border-color', 'lightgrey');
    }
    if ($('#municipio').val().trim() == "") {
        $('#municipio').css('border-color', 'Red');
        Valido = false;
    }
    else {
        $('#municipio').css('border-color', 'lightgrey');
    }
    return Valido;
}
function GetData(tbody, html) {
    $(tbody).on('click', '#btnEditar', function () {
        var objDatos = html.row(this).parents('tr').data();
        $('#codigo').val(objDatos.Codigo);
        $('#municipio').val(objDatos.Municipio);
        $('#estado').val(objDatos.Codigo_region);
        $('#cbxRegion').val(objDatos.IdTienda);
        $("#codigo").attr("readonly", "readonly");
    });
}
