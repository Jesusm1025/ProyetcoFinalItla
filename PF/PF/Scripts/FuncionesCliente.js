var TelItems = new Listas();
var dirrecionesItems = new Listas();
var emailItems = new Listas();

function MostrarDirrecion(editar) {
    $('#dirrecionesItems').html('');
    if (dirrecionesItems.Total() > 0) {
        var $table = $('<table class = "table table-bordered table-striped table-responsive"/>');
        if (editar)
            $table.append('<thead><tr><th>Provincia</th><th>Municipio</th><th>Barrio</th><th>Calle</th><th>Opcion</th></tr></thead>');
        else
            $table.append('<thead><tr><th>Provincia</th><th>Municipio</th><th>Barrio</th><th>Calle</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < dirrecionesItems.Total(); i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(dirrecionesItems.Item(i).Provincia));
            $row.append($('<td/>').html(dirrecionesItems.Item(i).Municipio));
            $row.append($('<td/>').html(dirrecionesItems.Item(i).Barrio));
            $row.append($('<td/>').html(dirrecionesItems.Item(i).Calle));
            if (editar)
                $row.append($('<td/>').html("a href = '#' class = 'btn btn-primary' data-toggle = 'tooltip' title = 'Eliminar' onClick = 'return EliminarDir(" + i + ");'><span class = 'glyphicon glyphicon-trash' aria-hidden = 'true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#dirrecionesItems').html($table);
    }
}

function MostrarEmail(editar) {
    $('#emailItems').html('');
    if (emailItems.Total() > 0) {
        var $table = $('<table class = "table table-bordered table-striped table-responsive"/>');
        if (editar)
            $table.append('<thead><tr><th>Email</th><th>Direccion</th><th>Principal</th><th>Opcion</th></tr></thead>');
        else
            $table.append('<thead><tr><th>Email</th><th>Direccion</th><th>Principal</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < emailItems.Total(); i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(emailItems.Item(i).Direcion));
            $row.append($('<td/>').html(emailItems.Item(i).Principal));
            if (editar)
                $row.append($('<td/>').html("a href = '#' class = 'btn btn-primary' data-toggle = 'tooltip' title = 'Eliminar' onClick = 'return EliminarEm(" + i + ");'><span class = 'glyphicon glyphicon-trash' aria-hidden = 'true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#emailItems').html($table);
    }
}

function MostrarTelefono(editar) {
    $('#TelItems').html('');
    if (TelItems.Total() > 0) {
        var $table = $('<table class = "table table-bordered table-striped table-responsive"/>');
        if (editar)
            $table.append('<thead><tr><th>Telefono</th><th>Tipo</th><th>Principal</th><th>Opcion</th></tr></thead>');
        else 
            $table.append('<thead><tr><th>Telefono</th><th>Tipo</th><th>Principal</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < TelItems.Total(); i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(TelItems.Item(i).NumeroTelefonico));
            $row.append($('<td/>').html(TelItems.Item(i).Tipo));
            $row.append($('<td/>').html(TelItems.Item(i).Principal));
            if (editar)
                $row.append($('<td/>').html("a href = '#' class = 'btn btn-primary' data-toggle = 'tooltip' title = 'Eliminar' onClick = 'return EliminarTel(" + i + ");'><span class = 'glyphicon glyphicon-trash' aria-hidden = 'true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#TelItems').html($table);
    }
}

function addEmail_Click() {
    var isValidItem = true;
    if ($('#Email').val().trim() == '') {
        isValidItem = false;
        $('#Email').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Email').siblings('span.error').css('visibility', 'hidden');
    }

    if (isValidItem) {
        var vPrincipal;
        if ($('#EmailPrincipal').is(':checked')) {
            vPrincipal = true
        }
        else
            vPrincipal = false
        emailItems.Agregar({
            EmailId: 0,
            Direccion: $('#Email').val().trim(),
            Principal: vPrincipal,
        });
        $('#Email').val('').focus();
        $('#EmailPrincipal').val('');
    }

    MostrarEmail(true);
}

function addDir_Click() {
    var isValidItem = true;
    if ($('#Provicincia').val().trim() == '') {
        isValidItem = false;
        $('#Provincia').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Provincia').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Municipio').val().trim() == '') {
        isValidItem = false;
        $('#Municipio').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Municipio').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Barrio').val().trim() == '') {
        isValidItem = false;
        $('#Barrio').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Barrio').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Calle').val().trim() == '') {
        isValidItem = false;
        $('#Calle').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Calle').siblings('span.error').css('visibility', 'hidden');
    }
    if (isValidItem) {
        var vPrincipal;
        if ($('#DirPrincipal').is(':checked')) {
            vPrincipal = true
        }
        else
            vPrincipal = false
        dirreccionesItems.Agregar({
            DireccionId: 0,
            Provincia: $('#Provincia').val().trim(),
            Tipo: $('#Municipio').val().trim(),
            Tipo: $('#Barrio').val().trim(),
            Tipo: $('#Calle').val().trim(),
            Principal: vPrincipal,
        });
        $('#Provincia').val('').focus();
        $('#Municipio').val('');
        $('#Barrio').val('');
        $('#Calle').val('');
        $('#DirPrincipal').attr('checked', false);
    }

    MostrarDirrecion(true);
}

function addTel_Click() {
    var isValidItem = true;
    if ($('#Telefono').val().trim() == '') {
        isValidItem = false;
        $('#Telefono').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Telefono').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Tipo').val().trim() == '') {
        isValidItem = false;
        $('#Tipo').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Tipo').siblings('span.error').css('visibility', 'hidden');
    }
    if (isValidItem) {
        var vPrincipal;
        if ($('#TelPrincipal').is(':checked')) {
            vPrincipal = true
        }
        else 
            vPrincipal = false
            TelItems.Agregar({
                TelefonoId: 0,
                NumeroTelefonico: $('#Telefono').val().trim(),
                Tipo: $('#Tipo').val().trim(),
                Principal: vPrincipal,
            });
        $('#Telefono').val('').focus();
        $('#Tipo').val('');
        $('#TelPrincipal').attr('checked', false);
    }

    MostrarTelefono(true);
}

function EliminarTel(indice) {
    TelItems.Eliminar(indice);
    MostrarTelefono(true);
    return false;
}
function EliminarDir(indice) {
    dirreccionesItems.Eliminar(indice);
    MostrarDirrecion(true);
    return false;
}
function EliminarEm(indice) {
    emailItems.Eliminar(indice);
    MostrarEmail(true);
    return false;
}

function crear_Click() {
    var isAllValid = true;

    if ($('#Nombre').val().trim() == '') {
        $('#Nombre').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#Nombre').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#TipoClienteId').val().trim() == '') {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'hidden');
    }
    if (isAllValid) {
        var data = {
            ClienteId = 0,
            Nombre: $('#Nombre').val().trim(),
            RNC: $('#RNC').val().trim(),
            TipoClienteId: $('#TipoClienteId').val().trim(),
            Telefonos: TelItems.Listas(),
            Dirreciones: dirrecionesItems.Listas(),
            Emails: emailItems.Listas()
        }
        var token = $('[name=_RequestVerificationToken]').val();

        $.ajax({
            url: '/Clientes/Create',
            type: "POST",
            data: { _ResquestVerificationToken: token, cliente: data },
            success: function (d) {
                if (d == true) {
                    window.location.href = '/Cliente/index';
                }
                else {
                    alert('Hubo un error al momento de guardar');
                }
            },
            error: function () {
                alert('Error, vuelva a intentarlo')
            }
        });
    }
}