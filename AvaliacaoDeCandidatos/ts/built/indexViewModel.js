var IndexViewModel = /** @class */ (function () {
    function IndexViewModel() {
        this.nome = ko.observable('');
        this.email = ko.observable('');
        this.temErroNoNome = ko.observable(false);
        this.temErroNoEmail = ko.observable(false);
        this.notaHtml = ko.observable(0);
        this.notaCss = ko.observable(0);
        this.notaJs = ko.observable(0);
        this.notaPython = ko.observable(0);
        this.notaDjango = ko.observable(0);
        this.notaIos = ko.observable(0);
        this.notaAndroid = ko.observable(0);
        this.passo = ko.observable(1);
        this.resultado = ko.observable('');
        this.tentativasDeCadastro = ko.observable(0);
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
    IndexViewModel.prototype.atualizeTentativas = function () {
        var tentativas = this.tentativasDeCadastro() + 1;
        this.tentativasDeCadastro(tentativas);
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
            _this.resultado(result);
            _this.andarPasso();
        })
            .fail(function () {
            alert('Ops. Algo errado não está certo. Tente novamente');
            _this.atualizeTentativas();
            if (_this.tentativasDeCadastro() >= 3) {
                _this.resultado("Infelizmente não foi possível efetuar o cadastro. Por favor, tente novamente mais tarde.");
                _this.andarPasso();
            }
        });
    };
    return IndexViewModel;
}());
//# sourceMappingURL=indexViewModel.js.map