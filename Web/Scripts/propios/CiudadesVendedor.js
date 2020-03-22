
$(function () {
    Listar();
});

function Agregar(_id) {
   // this.addEventListener("submit", my_func, true);
    var parametros = {};
    if (typeof (_id) !== 'undefined') {
        parametros = { id: _id };
    }
    $.ajax({
        cache: false,
        async: true,
        type: "GET",
        url: URLAgregar,
        data: parametros,
        success: function (response) {

            $('#modal-agregar').modal('show');
            $('#div-agregar').html('');
            $('#div-agregar').html(response);

            Listar();
        }
    });
}

function Eliminar(_id) {

    var parametros = {};

    if (typeof (_id) !== 'undefined') {
        parametros = { id: _id };
    }

    $.ajax({
        cache: false,
        async: true,
        type: "GET",
        url: URLEliminar,
        data: parametros,
        success: function (response) {
            Listar();
        }
    });
}

function Listar() {
   
    $.ajax({
        cache: false,
        async: true,
        type: "GET",
        url: URLListar,
        data: {},
        success: function (response) {
            $('#listardatos').html('');
            $('#listardatos').html(response);
        }
    }).fail(function () {
    });
}


/// vendedores

var my_func = function (event) {
    event.preventDefault();
};


function AgregarVendedor(_id) {
     this.addEventListener("submit", my_func, true);
    var _ciudad = $('#ciudad_CiudadId').val();
    var parametros = {};
    //if (typeof (_id) !== 'undefined') {
    //    parametros = { id: _id, ciudad: _ciudad };
    //}
    $.ajax({
        cache: false,
        async: true,
        type: "GET",
        url: URLAgregarVendedor,
        data: { id: _id, ciudad: _ciudad },
        success: function (response) {

            $('#modalagregar').modal('show');
            $('#divagregar').html('');
            $('#divagregar').html(response);

            //ListarVendedores($('#Ci').vl());
        }
    });
}


function ListarVendedores(_id) {
   
    $.ajax({
        cache: false,
        async: true,
        type: "GET",
        url: URLListarVendedor,
        data: {id:_id},
        success: function (response) {
            $('#detallevendedor').html('');
            $('#detallevendedor').html(response);
        }
    }).fail(function () {
    });
}


