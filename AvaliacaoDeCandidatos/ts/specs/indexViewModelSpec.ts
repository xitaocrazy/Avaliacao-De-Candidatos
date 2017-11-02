describe("Dado um IndexViewModel", () =>{
    var vm: main.modulos.IndexViewModel;
    beforeEach(() => {
        vm = new main.modulos.IndexViewModel();
    });
    describe("quando construir o objeto", () =>{
        it("deve setar nome conforme esperado", () =>{
            expect(vm.nome()).toEqual('');
        })
        it("deve setar email conforme esperado", () =>{
            expect(vm.email()).toEqual('');
        })
        it("deve setar temErroNoNome conforme esperado", () =>{
            expect(vm.temErroNoNome()).toBeFalsy();
        })
        it("deve setar temErroNoEmail conforme esperado", () =>{
            expect(vm.temErroNoEmail()).toBeFalsy();
        })
        it("deve setar notaHtml conforme esperado", () =>{
            expect(vm.notaHtml()).toEqual(0);
        })
        it("deve setar notaCss conforme esperado", () =>{
            expect(vm.notaCss()).toEqual(0);
        })
        it("deve setar notaJs conforme esperado", () =>{
            expect(vm.notaJs()).toEqual(0);
        })
        it("deve setar notaPython conforme esperado", () =>{
            expect(vm.notaPython()).toEqual(0);
        })
        it("deve setar notaDjango conforme esperado", () =>{
            expect(vm.notaDjango()).toEqual(0);
        })
        it("deve setar notaIos conforme esperado", () =>{
            expect(vm.notaIos()).toEqual(0);
        })
        it("deve setar notaAndroid conforme esperado", () =>{
            expect(vm.notaAndroid()).toEqual(0);
        })
        it("deve setar passo conforme esperado", () =>{
            expect(vm.passo()).toEqual(1);
        })
        it("deve setar resultado conforme esperado", () =>{
            expect(vm.resultado()).toEqual('');
        })
        it("deve setar tentativasDeCadastro conforme esperado", () =>{
            expect(vm.tentativasDeCadastro()).toEqual(0);
        })
    });    
})