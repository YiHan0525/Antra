function Calculator(screenId){
    this.expression = "0";
    this.calculatorScreen = document.getElementById(screenId);
    this.calculatorScreen.value = this.expression;
}

Calculator.prototype.addChar = function(symbol){
    if(this.expression == "0"){
        this.expression = "";
    }
    this.expression += symbol;
    this.calculatorScreen.value = this.expression;
}

Calculator.prototype.printResult = function(){
    try{
        this.calculatorScreen.value = eval(this.expression);
    }
    catch(e){
        this.calculatorScreen.value = "Error";
    }finally{
        this.expression = "0";
    }
}

Calculator.prototype.clearScr = function(){
    this.expression = "0";
    this.calculatorScreen.value = this.expression;
}

calculator = new Calculator("screen");