$(document).ready(function () {
    $('#btnNotificacion').hide();
    $('#codigo').hide();
    $('#btnActualizar').hide();

    //Metodo cargar tabla
    loadDataTable();

    //Llenar combobox municipio
    $.ajax({
        url: '/Region/listarMunicipio/',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var clasificacion = $("#cbxMunicipio");
            var datos = data.data;
            $(datos).each(function (i, v) {
                clasificacion.append('<option value="' + v.Codigo_Municipio + '">' + v.Nombre_Municipio + '</option>');
            });
        },
        error: function () {
            console.log('error');
        }
    });

    //Llenar datos la tabla
    function loadDataTable() {

        var table = $('#datatable').DataTable({
            "processing": true,
            "ajax": {
                "url": '/Region/listar/',
                "type": "GET"
            },
            "columns": [
                { "data": "CodigoR" },
                { "data": "Nombre" },
                { "data": "CodigoM" },
                { "data": "NombreM" },
                { "defaultContent": " <button class='btn btn-info' id='btnEditar'><span class='glyphicon glyphicon-pencil'></span></button> <button class='btn btn-danger' id='btnEliminar'><span class='glyphicon  glyphicon-trash'></span></button>" }
            ]
        });
        GetData("#datatable", table);
    }

    //Capturar los datos de la fila e imprimmir en los input para editar
    function GetData(tbody, table) {
        $(tbody).on('click', '#btnEditar', function () {
            var objDatos = table.row($(this).parents('tr')).data();
            $('#codigo').show();
            $('#codigo').val(objDatos.CodigoR);
            $('#region').val(objDatos.Nombre);
            $('#cbxMunicipio').val(objDatos.CodigoM);
            $("#codigo").attr("readonly", "readonly");
            $('#btnActualizar').show();
            $('#btnGuardar').hide();
        });

        $('#btnActualizar').click(function () {

            var resultado = validacionRegion();
            if (resultado == false) {
                return false;
            }
            //declarar objeto
            actualizarRegion = {};
            actualizarRegion.CodigoR = $('#codigo').val();
            actualizarRegion.Nombre = $('#region').val();
            actualizarRegion.CodigoM = $('#cbxMunicipio').val();
            //nuevoMunicipio.Municipio = $('#cbxRegion').val();
            //nuevoProducto.IdTienda = $('#cbxTienda').val();

            $.ajax({
                url: '/Region/Actualizar/',
                type: 'POST',
                dataType: 'json',
                data: actualizarRegion,
                success: function (data) {
                    var result = data.data;
                    var texto = "Se actualizo correctamente";
                    $('#lblmensaje').text(texto);
                    $('#divmensaje').addClass('alert alert-success');
                    $('#divmensaje').show();
                    setTimeout(function () {
                        $('#divmensaje').fadeOut(1000);
                    }, 2000);
                    $('#datatable').DataTable().ajax.reload();
                    $('#codigo').val('');
                    $('#region').val('');
                    $('#cbxMunicipio').val('');
                    $("#codigo").removeAttr("readonly");
                    $('#btnActualizar').hide();
                    $('#btnGuardar').show();
                    $('#codigo').hide();
                },
                error: function () {
                    var texto = "No se guardo el registro";
                    $('#lblmensaje').text(texto);
                    $('#divmensaje').addClass('alert alert-danger');
                    $('#divmensaje').show();
                    setTimeout(function () {
                        $('#divmensaje').fadeOut(1000);
                    }, 2000);

                    $('#codigo').val('');
                    $('#region').val('');
                    $('#cbxMunicipio').val('');
                    $("#codigo").removeAttr("readonly");
                    $('#btnActualizar').hide();
                    $('#btnGuardar').show();
                }
            });
        });

        $(tbody).on('click', '#btnEliminar', function () {
            var objDatos = table.row($(this).parents('tr')).data();
            var datos = {};
            datos.CodigoR = objDatos.CodigoR;
            datos.CodigoM = objDatos.CodigoM;
            $.ajax({
                url: '/Region/EliminarRegion/',
                type: 'POST',
                dataType: 'json',
                data: datos,
                success: function (data) {
                    var result = data.data;
                    var texto = "Se elimino corretamente la informacion";
                    $('#lblmensaje').text(texto);
                        $('#divmensaje').addClass('alert alert-success');
                        $('#divmensaje').show();
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
                    setTimeout(function () {
                        $('#divmensaje').fadeOut(1000);
                    }, 2000);
                }
            });

        });
    }

    $('#btnGuardar').click(function () {

        var resultado = validacionRegion();
        if (resultado == false) {
            return false;
        }
        //declarar objeto
        nuevaRegion = {};
        //nuevaRegion.CodigoR = $('#codigo').val();
        nuevaRegion.Nombre = $('#region').val();
        nuevaRegion.CodigoM = $('#cbxMunicipio').val();
        //nuevoMunicipio.Municipio = $('#cbxRegion').val();
        //nuevoProducto.IdTienda = $('#cbxTienda').val();

        $.ajax({
            url: '/Region/guardarRegion/',
            type: 'POST',
            dataType: 'json',
            data: nuevaRegion,
            success: function (data) {
                var result = data.data;
                var texto = "Se guardo region exitosamente";
                $('#lblmensaje').text(texto);
                    $('#divmensaje').addClass('alert alert-success');
                    $('#divmensaje').show();
                    setTimeout(function () {
                        $('#divmensaje').fadeOut(1000);
                    }, 2000);
                    $('#datatable').DataTable().ajax.reload();
                $('#codigo').val('');
                $('#region').val('');
                $('#cbxMunicipio').val('');
            },
            error: function () {
                var texto = "No se guardo el registro";
                $('#lblmensaje').text(texto);
                $('#divmensaje').addClass('alert alert-danger');
                $('#divmensaje').show();
                setTimeout(function () {
                    $('#divmensaje').fadeOut(1000);
                }, 2000);
                $('#datatable').DataTable().ajax.reload();
                $('#codigo').val('');
                $('#region').val('');
                $('#cbxMunicipio').val('');
                $("#codigo").removeAttr("readonly");
            }
        });
    });

    function validacionRegion() {
        var Valido = false;
        if ($('#codigo').val().trim() == "") {
            $('#codigo').css('border-color', 'Red');
            Valido = false;
        }
        else {
            $('#codigo').css('border-color', 'lightgrey');
            return true;
        }
        if ($('#region').val().trim() == "") {
            $('#region').css('border-color', 'Red');
            Valido = false;
        }
        else {
            $('#region').css('border-color', 'lightgrey');
            return true;
        }
        return Valido;
    }
});