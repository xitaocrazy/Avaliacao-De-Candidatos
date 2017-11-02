describe("Dado um IndexViewModel", function () {
    var vm;
    beforeEach(function () {
        vm = new main.modulos.IndexViewModel();
    });
    describe("quando construir o objeto", function () {
        it("deve setar nome conforme esperado", function () {
            expect(vm.nome()).toEqual('');
        });
        it("deve setar email conforme esperado", function () {
            expect(vm.email()).toEqual('');
        });
        it("deve setar temErroNoNome conforme esperado", function () {
            expect(vm.temErroNoNome()).toBeFalsy();
        });
        it("deve setar temErroNoEmail conforme esperado", function () {
            expect(vm.temErroNoEmail()).toBeFalsy();
        });
        it("deve setar notaHtml conforme esperado", function () {
            expect(vm.notaHtml()).toEqual(0);
        });
        it("deve setar notaCss conforme esperado", function () {
            expect(vm.notaCss()).toEqual(0);
        });
        it("deve setar notaJs conforme esperado", function () {
            expect(vm.notaJs()).toEqual(0);
        });
        it("deve setar notaPython conforme esperado", function () {
            expect(vm.notaPython()).toEqual(0);
        });
        it("deve setar notaDjango conforme esperado", function () {
            expect(vm.notaDjango()).toEqual(0);
        });
        it("deve setar notaIos conforme esperado", function () {
            expect(vm.notaIos()).toEqual(0);
        });
        it("deve setar notaAndroid conforme esperado", function () {
            expect(vm.notaAndroid()).toEqual(0);
        });
        it("deve setar passo conforme esperado", function () {
            expect(vm.passo()).toEqual(1);
        });
        it("deve setar resultado conforme esperado", function () {
            expect(vm.resultado()).toEqual('');
        });
        it("deve setar tentativasDeCadastro conforme esperado", function () {
            expect(vm.tentativasDeCadastro()).toEqual(0);
        });
    });
});
//# sourceMappingURL=indexViewModelSpec.js.map