var IndexViewModel = /** @class */ (function () {
    function IndexViewModel() {
        this.nome = ko.observable('');
        this.email = ko.observable('');
        this.temErroNoNome = ko.observable(false);
        this.temErroNoEmail = ko.observable(false);
    }
    IndexViewModel.prototype.ehNomeValido = function () {
        this.temErroNoNome(false);
        var er = /^([a-zA-ZáéíóúàâêôãõüçÁÉÍÓÚÀÂÊÔÃÕÜÇ ]|\n){2,50} ([a-zA-ZáéíóúàâêôãõüçÁÉÍÓÚÀÂÊÔÃÕÜÇ ]|\n){2,50}$/;
        if (!er.exec(this.nome())) {
            this.temErroNoNome(true);
        }
    };
    IndexViewModel.prototype.ehEmailValido = function () {
        this.temErroNoEmail(false);
        var er = /^[A-Za-z0-9](([_.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*)([.][A-Za-z]{2,4})$/;
        if (!er.exec(this.email())) {
            this.temErroNoEmail(true);
        }
    };
    IndexViewModel.prototype.iniciarCadastro = function () {
        this.ehNomeValido();
        this.ehEmailValido();
        if (!this.temErroNoNome() && !this.temErroNoEmail()) {
        }
    };
    ;
    return IndexViewModel;
}());
//# sourceMappingURL=index.js.map