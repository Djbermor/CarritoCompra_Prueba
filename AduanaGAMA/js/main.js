
let vista = 0;
let IdUsuario = "";
let nombre = "";
let cantidad = "";

function ValidarCompos() {
    if ($(nombre).val() === "" || $(direccion).val() === "" || $('#telefono').val() === "" || $(usuario).val() === "" || $(contrasenna).val() === "") {
        return false;
    } else {
        return true;
    }
}

function ValidarStock(stock) {
    if (stock === "0") {
        return false;
    } else {
        return true;
    }
}

function ValidarLogin() {
    if ($(usuario).val() === "" || $(contrasenna).val() === "") {
        return false;
    } else {
        return true;
    }
}

function ValidarProducto() {
    if ($(nombre).val() === "" || $(descripcion).val() === "" || $(precio).val() === "" || $(stock).val() === "") {
        return false;
    } else {
        return true;
    }
}

function ValidarIdUsuario(id) {
    if (id === "") {
        return false;
    } else {
        return true;
    }
}

function incrementarCarrito() {
    var url = new URL(window.location.href);
    var cantidad = url.searchParams.get("cantidad");
    var contadorCar = document.getElementById("contadorCarrito");
    var cantidadArticulo = document.getElementById("cantidad_articulos");
    if (contadorCar && cantidad) {
        contadorCar.textContent = cantidad;
    }
    if (cantidadArticulo) {
        cantidadArticulo.textContent = cantidad;
    }
}


function GestionarCarrito(idProducto, id = null, stock = null) {
    if (!ValidarStock(stock)) {
        alert("¡La cantidad de articulo no se encuentra disponible!");
    } else if (id != "Eliminar") {
        var url = new URL(window.location.href);
        IdUsuario = url.searchParams.get("id");
        let data = CrearJsonCarrito(idProducto, IdUsuario, id);
        data = {
            'carrito': data
        };
        post({ typeHTTP: 'POST', method: 'GestionarCarrito', data: data });
    } else if (window.confirm("Este articulo sera eliminado, ¿Desea continuar?")) {
        var url = new URL(window.location.href);
        IdUsuario = url.searchParams.get("id");
        let data = CrearJsonCarrito(idProducto, IdUsuario, id);
        data = {
            'carrito': data
        };
        post({ typeHTTP: 'POST', method: 'GestionarCarrito', data: data });
    }
}


function Comprar() {
    var url = new URL(window.location.href);
    IdUsuario = url.searchParams.get("id");
    let data = CrearJsonCarrito(null, IdUsuario);
    data = {
        'carrito': data
    };
    post({ typeHTTP: 'POST', method: 'Comprar', data: data });
}

function ConsultarDetalle(nfactura) {
    data = {
        'carrito': nfactura
    };
    post({ typeHTTP: 'POST', method: 'ConsultarDetalleCompra', data: data });
}

function Direccionamiento(page) {
    var url = new URL(window.location.href);
    IdUsuario = url.searchParams.get("id");
    cantidad = url.searchParams.get("cantidad");
    mensajes(page);
}

function Login() {
    if (!ValidarLogin()) {
        alert("¡Por favor Diligenciar todo los campos!");
    } else {
        IniciarSesion();
    }
}

function GuardarProducto() {
    if (!ValidarProducto()) {
        alert("¡Por favor Diligenciar todo los campos!");
    } else {
        RegistrarProducto();
    }
}

function GuardarDatos() {
    if (!ValidarCompos()) {
        alert("¡Por favor Diligenciar todo los campos!");
    } else {
        GuardarUsuario();
    }
}

function CrearJson() {
    return {
        "Nombre": $('#nombre').val(),
        "Direccion": $('#direccion').val(),
        "Telefono": $('#telefono').val(),
        "Login": $('#usuario').val(),
        "Contrasenna": $('#contrasenna').val(),
        "rol": 0
    };
}

function CrearJsonProducto() {
    return {
        "Nombre": $('#nombre').val(),
        "Descripcion": $('#descripcion').val(),
        "Precio": $('#precio').val(),
        "Stock": $('#stock').val()
    };
}

function CrearJsonCarrito(IdProducto, IdUsuario, id=null) {
    return {
        "Id": id,
        "IdUsuario": IdUsuario,
        "IdProducto": IdProducto
    };
}

function GuardarUsuario() {
    let data = CrearJson();

    data = {
        'usuario': data
    };

    post({ typeHTTP: 'POST', method: 'RegistrarUser', data: data});
}

function RegistrarProducto() {
    let data = CrearJsonProducto();

    data = {
        'producto': data
    };

    post({ typeHTTP: 'POST', method: 'RegistrarProducto', data: data });
}

function IniciarSesion() {
    let data = CrearJson();

    data = {
        'usuario': data
    };

    post({ typeHTTP: 'POST', method: 'IniciarSesion', data: data });
}

//function arrow
const post = ({ typeHTTP, method, data }) => {
    const request = new XMLHttpRequest();

    if (!request) {
        console.log(new Error('el navegador no soporta XmlHttpRequest'));
        return;
    }

    let pathname = window.location.pathname === '/' ? 'Default.aspx' : window.location.pathname;

    request.open(typeHTTP, `${pathname}/${method}`, true);
    //request.open('POST', 'Default.aspx', true);

    request.onreadystatechange = function () {
        if (request.readyState === XMLHttpRequest.DONE) {
            if (request.status === 200) {
                let responseText = request.responseText;
                try {
                    let response = JSON.parse(responseText).d;

                    mensajes(response);
                    console.log(response);
                } catch (ex) {
                    console.log(ex);
                    console.log(responseText);
                    mensajes(response);
                }
            }
            else {
                console.log('problemas con la peticion');
            }
        } 
    };

    request.setRequestHeader('Cache-Control', 'no-cache');
    request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');

    //envia la peticion
    request.send(JSON.stringify(data));
};

function mensajes(response) {
    var dataUser = response.split(" ");
    
    if (response === "Compra " + dataUser[1] || response === "Tienda " + dataUser[1] || response === "Carrito " + dataUser[1]) {
        response = dataUser[0];
        cantidad = dataUser[1];
    }

    if (cantidad === "") { 
        for (var i = 0; i < dataUser.length; i++) {
            if (i === 0) {
                response = dataUser[i];
            }
            if (i === 1) {
                IdUsuario = dataUser[i];
            }
            if (i === 2) {
                cantidad = dataUser[i];
            }
        }
    }

    const redirect = () => window.location.href = 'Login.aspx';
    const redirectLoginError = () => window.location.href = 'Login.aspx';
    const redirectLogin = () => window.location.href = 'Login.aspx';
    const redirectTienda = () => window.location.href = 'Default.aspx?id=' + IdUsuario + '&cantidad=' + cantidad;
    const redirectAdmin = () => window.location.href = 'Menu.aspx';
    const redirectRegistro = () => window.location.href = 'Registrar.aspx';
    const redirectTransacciones = () => window.location.href = 'Transacciones.aspx';
    const redirectProducto = () => window.location.href = 'Producto.aspx';
    const redirectCarrito = () => window.location.href = 'Carrito.aspx?id=' + IdUsuario +  '&cantidad=' + cantidad;

    switch (response) {
        case 'Tienda':
            redirectTienda();
            break;
        case 'Admin':
            redirectAdmin();
            break;
        case 'Transacciones':
            redirectTransacciones();
            break;
        case 'Producto':
            redirectProducto();
            break;
        case 'Carrito':
            redirectCarrito();
            break;
        case 'Login':
            swal('Acción realizada correctamente ', '', "success").then(() => redirectLogin()).catch(() => redirectLogin());
            break;
        case 'Compra':
            swal('Compra realizada correctamente ', '', "success").then(() => redirectTienda()).catch(() => redirectTienda());
            break;
        case 'LoginError':
            swal('Oops', 'Hubo problemas con su usuario o contraseña. por favor corregir. Y si no tiene usuario, por favor registrarse!').then(() => redirectLoginError()).catch(() => redirectLoginError());
            break;
        case 'Registro':
            swal('Oops', 'Hubo problemas con su registro. Usuario existente.').then(() => redirectRegistro()).catch(() => redirectRegistro());
            break;
        default:
            swal('Oops', 'Hubo problemas con su petición. por favor intente más tarde.').then(() => redirect()).catch(() => redirect());
            break;
    }
}

document.addEventListener("DOMContentLoaded", () => {
    incrementarCarrito();
});

function FiltrarDetalle(nfactura) {
    var gridViewDetalle = document.getElementById("gridViewDetalle");
    var filasDetalle = gridViewDetalle.getElementsByTagName("tr");
    var total = 0;
    let cant = 0;

    for (var i = 1; i < filasDetalle.length; i++) {
        filasDetalle[i].style.display = "none";
    }

    for (var i = 1; i < filasDetalle.length; i++) {
        var celdas = filasDetalle[i].getElementsByTagName("td");
        if (celdas.length > 0 && celdas[0].textContent.trim() === nfactura) {
            filasDetalle[i].style.display = "";
            total = total + parseInt(celdas[4].textContent.trim());
            cant = cant + parseInt(celdas[3].textContent.trim());
        }
        
    }
    //var cantidadArticulo = document.getElementById("total");
    //var totalValor = document.getElementById("cantidad");
    //totalValor.textContent = total.toString();
    //cantidadArticulo.textContent = cant.toString();
}


