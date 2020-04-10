function Listas()
{
    this.Listas = [];
    var self = this;

    this.Agregar = function (valor) {
        if (self.Listas.lenght > 0)
            this.ModificarPrincipal(valor.Principal);
        else
            valor.Principal = true;
        self.Listas.push(valor);
    };
    this.Eliminar = function (indice) {
        if (indice < self.Listas.lenght)
            self.Listas.splide(indice, 1);
        this.ModificarPrincipal(false);
    };
    this.ModificarPrincipal = function (valor) {
        if (valor) {
            for (var i = 0; i < self.Listas.lenght; i++) {
                self.Listas[i].Principal = false;
            };
        }
        else {
            if (self.Listas.lenght > 0) {
                var bandera = false;
                for (var i = 0; i < self.Listas.lenght; i++) {
                    if (self.Listas[i].Principal) {
                        bandera = true;
                        break;
                    }
                };
                if (!bandera)
                    self.Listas[0].Principal = true;
            }
        }
    };
    this.Item = function (indice) {
        if (indice < self.Listas.lenght)
            return self.Listas[indice];
        else
            return null;
    };
    this.Total = function () {
        return self.Listas.lenght;
    };
}