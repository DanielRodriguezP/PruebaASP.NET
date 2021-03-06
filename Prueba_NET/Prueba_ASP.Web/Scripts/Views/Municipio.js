﻿$(document).ready(function () {
    //Ocultar notificacion y button
    $('#btnNotificacion').hide();
    $('#btnActualizar').hide();

    //Cargar tabla
    loadDataTable();

    $.ajax({
        url: '/Municipio/listarRegion/',
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
    //Cargar tabla
    function loadDataTable() {

        var table = $('#datatable').DataTable({
            "processing": true,
            "ajax": {
                "url": '/Municipio/listar/',
                "type": "GET"
            },
            "columns": [
                { "data": "Codigo_Municipio" },
                { "data": "Nombre_Municipio" },
                { "data": "Estado" },
                { "data": "Codigo_Region" },
                { "data": "Nombre_Region" },
                { "defaultContent": " <button class='btn btn-info' id='btnEditar'><span class='glyphicon glyphicon-pencil'></span></button> <button class='btn btn-danger' id='btnEliminar'><span class='glyphicon  glyphicon-trash'></span></button>" }
            ]
        });
        GetData("#datatable", table);
    }

    //caturar datos e imprimir en los input
    function GetData(tbody, table) {
        $(tbody).on('click', '#btnEditar', function () {
            var objDatos = table.row($(this).parents('tr')).data();
            $('#codigo').val(objDatos.Codigo_Municipio);
            $('#municipio').val(objDatos.Nombre_Municipio);
            $('#estado').val(objDatos.Estado);
            $('#cbxRegion').val(objDatos.Codigo_Region);
            $("#codigo").attr("readonly", "readonly");
            $('#btnActualizar').show();
            $('#btnGuardar').hide();
        });

        //Actualizar informacion
        $('#btnActualizar').click(function () {

            var resultado = validacionMunicipio();
            if (resultado == false) {
                return false;
            }
            //declarar objeto
            actualizarRegion = {};
            actualizarRegion.Codigo_Municipio = $('#codigo').val();
            actualizarRegion.Nombre_Municipio = $('#municipio').val();
            actualizarRegion.Estado = $('#estado').attr('checked');
                //$('#estado').val();
            actualizarRegion.Codigo_region = $('#cbxRegion').val();
            
            $.ajax({
                url: '/Municipio/Actualizar/',
                type: 'POST',
                dataType: 'json',
                data: actualizarRegion,
                success: function (data) {
                    var result = data.data;
                    var texto = "Se actualizo el registro";
                        $('#lblmensaje').text(texto);
                        $('#divmensaje').addClass('alert alert-success');
                        $('#divmensaje').show();
                        setTimeout(function () {
                            $('#divmensaje').fadeOut(1000);
                        }, 2000);
                        $('#datatable').DataTable().ajax.reload();
                        $('#codigo').val('');
                    $('#municipio').val('');
                    $('#estado').val('');
                        $('#cbxRegion').val();
                    $('#codigo').removeAttr("readonly");
                    $('#btnActualizar').hide();
                    $('#btnGuardar').show();
                    $('#estado').attr('checked', false);
                },
                error: function () {
                    var texto = "No se actualizo el registro";
                    $('#lblmensaje').text(texto);
                    $('#divmensaje').addClass('alert alert-danger');
                    $('#divmensaje').show();
                    setTimeout(function () {
                        $('#divmensaje').fadeOut(1000);
                    }, 2000);
                    $('#datatable').DataTable().ajax.reload();
                    $('#codigo').val('');
                    $('#municipio').val('');
                    $('#estado').val('');
                    $('#cbxRegion').val();
                    $("#codigo").removeAttr("readonly");
                    $('#btnActualizar').hide();
                    $('#btnGuardar').show();
                    $('#estado').attr('checked', false);
                }
            });
        });

        //Eliminar informacion
        $(tbody).on('click', '#btnEliminar', function () {
            var objDatos = table.row($(this).parents('tr')).data();
            var datos = {};
            datos.Codigo_region = objDatos.Codigo_Region;
            datos.Codigo_Municipio = objDatos.Codigo_Municipio;
            $.ajax({
                url: '/Municipio/EliminarMunicipio/',
                type: 'POST',
                dataType: 'json',
                data: datos,
                success: function (data) {
                    var result = data.data;
                    var texto = "Se Elimino el registro correctamente";
                        $('#lblmensaje').text(texto);
                        $('#divmensaje').addClass('alert alert-success');
                    $('#divmensaje').show();
                    $('#divmensaje').focus();
                        setTimeout(function () {
                            $('#divmensaje').fadeOut(1000);
                        }, 2000);
                        $('#datatable').DataTable().ajax.reload();
                },
                error: function () {
                    var texto = "No se eliminó el registro";
                    $('#lblmensaje').text(texto);
                    $('#divmensaje').addClass('alert alert-danger');
                    $('#divmensaje').show();
                    $('#divmensaje').focus();
                    setTimeout(function () {
                        $('#divmensaje').fadeOut(1000);
                    }, 2000);
                    $('#datatable').DataTable().ajax.reload();
                }
            });

        });
    }

    //Guardar informacion
    $('#btnGuardar').click(function () {

        var resultado = validacionMunicipio();
        if (resultado == false)
        {
            return false;
        }
        //declarar objeto
        nuevoMunicipio = {};
        nuevoMunicipio.Codigo_Municipio = $('#codigo').val();
        nuevoMunicipio.Nombre_Municipio = $('#municipio').val();
        nuevoMunicipio.Estado = $("#estado").is(":checked");
            //$('#estado:checked').val();
        nuevoMunicipio.Codigo_region = $('#cbxRegion').val();
        //nuevoProducto.IdTienda = $('#cbxTienda').val();

        $.ajax({
            url: '/Municipio/guardarMunicipio/',
            type: 'POST',
            dataType: 'json',
            data: nuevoMunicipio,
            success: function (data) {
                var result = data.data;
                var texto = "Se guardo el municipio correctamente";
                $('#lblmensaje').text(texto);
                $('#divmensaje').addClass('alert alert-success');
                $('#divmensaje').show();
                $('#divmensaje').focus();
                setTimeout(function () {
                    $('#divmensaje').fadeOut(1000);
                }, 2000);
                $('#datatable').DataTable().ajax.reload();
                $('#codigo').val('');
                $('#municipio').val('');
                $('#estado').val('');
                 $('#cbxRegion').val();
                $("#codigo").removeAttr("readonly");
                $('#estado').attr('checked', false);
            },
            error: function () {
                var texto = "No se guardo el registro";
                $('#lblmensaje').text(texto);
                $('#divmensaje').addClass('alert alert-danger');
                $('#divmensaje').show();
                $('#divmensaje').focus();
                setTimeout(function () {
                    $('#divmensaje').fadeOut(1000);
                }, 2000);
                $('#codigo').val('');
                $('#municipio').val('');
                $('#estado').val('');
                $('#cbxRegion').val();
                $("#codigo").removeAttr("readonly");
                $('#estado').attr('checked', false);
            }
        });
    }); 

    //Validaciones
    function validacionMunicipio() {
        var Valido = false;
        if ($('#codigo').val().trim() == "") {
            $('#codigo').css('border-color', 'Red');
            Valido = false;
        }
        else {
            $('#codigo').css('border-color', 'lightgrey');
            return true;
        }
        if ($('#municipio').val().trim() == "") {
            $('#municipio').css('border-color', 'Red');
            Valido = false;
        }
        else {
            $('#municipio').css('border-color', 'lightgrey');
            return true;
        }
        return Valido;
    }
});

