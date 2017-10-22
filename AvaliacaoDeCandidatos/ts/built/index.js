var IndexViewModel = /** @class */ (function () {
    function IndexViewModel() {
        this.nome = ko.observable('');
        this.email = ko.observable('');
        this.temErroNoNome = ko.observable(false);
        this.temErroNoEmail = ko.observable(false);
        this.notaHtml = ko.observable(5);
        this.notaCss = ko.observable(5);
        this.notaJs = ko.observable(5);
        this.notaPython = ko.observable(5);
        this.notaDjango = ko.observable(5);
        this.notaIos = ko.observable(5);
        this.notaAndroid = ko.observable(5);
        this.passo = ko.observable(1);
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
    IndexViewModel.prototype.andarPasso = function () {
        var passo = this.passo();
        if (passo < 3) {
            passo = passo + 1;
            this.passo(passo);
        }
    };
    IndexViewModel.prototype.voltarPasso = function () {
        var passo = this.passo();
        if (passo > 1) {
            passo = passo - 1;
            this.passo(passo);
        }
    };
    IndexViewModel.prototype.iniciarCadastro = function () {
        this.ehNomeValido();
        this.ehEmailValido();
        if (!this.temErroNoNome() && !this.temErroNoEmail()) {
            this.andarPasso();
        }
    };
    ;
    IndexViewModel.prototype.finalizarCadastro = function () {
        var _this = this;
        var candidato = {
            nome: this.nome(),
            email: this.email(),
            html: this.notaHtml(),
            css: this.notaCss(),
            javascript: this.notaJs(),
            python: this.notaPython(),
            django: this.notaDjango(),
            ios: this.notaIos(),
            android: this.notaAndroid()
        };
        var data = JSON.stringify(candidato);
        var url = "http://localhost:5000/api/candidatos";
        $.post({
            url: url,
            data: data,
            contentType: "application/json"
        })
            .done(function (result) {
            alert(result);
            _this.andarPasso();
        })
            .fail(function () {
            alert('Ops. Algo errado não está certo. Tente novamente');
        });
    };
    return IndexViewModel;
}());
//# sourceMappingURL=index.js.map