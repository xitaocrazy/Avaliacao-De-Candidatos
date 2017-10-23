class IndexViewModel {
    nome: KnockoutObservable<string>;
    email: KnockoutObservable<string>;
    temErroNoNome: KnockoutObservable<boolean>;
    temErroNoEmail: KnockoutObservable<boolean>;
    notaHtml: KnockoutObservable<number>;
    notaCss: KnockoutObservable<number>;
    notaJs: KnockoutObservable<number>;
    notaPython: KnockoutObservable<number>;
    notaDjango: KnockoutObservable<number>;
    notaIos: KnockoutObservable<number>;
    notaAndroid: KnockoutObservable<number>;
    passo: KnockoutObservable<number>;
    resultado: KnockoutObservable<string>;
    tentativasDeCadastro: KnockoutObservable<number>;

    constructor() {
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

    ehNomeValido(){
        this.temErroNoNome(false);
        var er = /^([a-zA-ZáéíóúàâêôãõüçÁÉÍÓÚÀÂÊÔÃÕÜÇ ]|\n){2,50} ([a-zA-ZáéíóúàâêôãõüçÁÉÍÓÚÀÂÊÔÃÕÜÇ ]|\n){2,50}$/; 
        if(!er.exec(this.nome())){
            this.temErroNoNome(true);
        }
    }  

    ehEmailValido(){
        this.temErroNoEmail(false);
        var er = /^[A-Za-z0-9](([_.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*)([.][A-Za-z]{2,4})$/; 
        if(!er.exec(this.email())){
            this.temErroNoEmail(true);
        }
    }

    atualizeTentativas(){
        var tentativas = this.tentativasDeCadastro() + 1;
        this.tentativasDeCadastro(tentativas);
    }

    public andarPasso(){
        var passo = this.passo();
        if (passo < 3){
            passo = passo + 1;
            this.passo(passo);
        }      
    }

    public voltarPasso(){
        var passo = this.passo();
        if (passo > 1){
            passo = passo - 1;
            this.passo(passo);
        }
    }

    public iniciarCadastro(){
        this.ehNomeValido();
        this.ehEmailValido();
        if(!this.temErroNoNome() && !this.temErroNoEmail()) {  
            this.andarPasso();                      
        }
    };

    public finalizarCadastro(){
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
        .done((result) => {
            this.resultado(result);
            this.andarPasso();
        })
        .fail(() => {
            alert('Ops. Algo errado não está certo. Tente novamente');
            this.atualizeTentativas();
            if (this.tentativasDeCadastro() >= 3){
                this.resultado("Infelizmente não foi possível efetuar o cadastro. Por favor, tente novamente mais tarde.");
                this.andarPasso();
            }
        });
    }
}