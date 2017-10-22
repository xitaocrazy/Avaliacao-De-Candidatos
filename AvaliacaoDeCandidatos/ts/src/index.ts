class IndexViewModel {
    nome: KnockoutObservable<string>;
    email: KnockoutObservable<string>;
    temErroNoNome: KnockoutObservable<boolean>;
    temErroNoEmail: KnockoutObservable<boolean>;

    constructor() {
        this.nome = ko.observable(''); 
        this.email = ko.observable('');
        this.temErroNoNome = ko.observable(false); 
        this.temErroNoEmail = ko.observable(false);
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

    public iniciarCadastro(){
        this.ehNomeValido();
        this.ehEmailValido();
        if(!this.temErroNoNome() && !this.temErroNoEmail()) {                        
        }
    };
}