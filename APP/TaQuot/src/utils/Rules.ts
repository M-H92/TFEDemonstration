export class Rule{
    //Tableau avec, pour chaque element, une condition et un message
    private rules =  [] as {condition : (input : string) => boolean, message : string}[];

    //On transforme chaque pair de condition/message en function retournant true ou le message
    public build(){
        return this.rules.map((r) => ((v : string) => r.condition(v) || r.message ) );
    }

    public withMessage(message : string){
        this.rules[this.rules.length - 1].message = message;
        return this;
    }

    public required(){
        this.rules.push({condition : (v : string) => !!v, message : 'Champ requis'});
        return this;
    }

    public isNumber(){
        this.rules.push({condition : (v : string) => (!v || !Number.isNaN(parseFloat(v))), message : 'Valeur numérique uniquement'});
        return this;
    }

    public maxLength(value : number){
        this.rules.push({condition : (v : string) => (!v || v.length <= value), message : `Taille maximum de ${value} caractères`});
        return this;
    }

    public minLength(value : number){
        this.rules.push({condition : (v : string) => (!v || v.length >= value), message : `Taille minimum de ${value} caractères`});
        return this;
    }

    public maxValue(value : number){
        this.rules.push({condition : (v : string) => (!v || parseFloat(v) <= value), message : `Valeur maximum : ${value}`});
        return this;
    }

    public minValue(value : number){
        this.rules.push({condition : (v : string) => (!v || parseFloat(v) >= value), message : `Valeur minimum : ${value}`});
        return this;
    }

    public isPositive(){
        return this.minValue(0).withMessage('Valeur positive uniquement');
    }

    public isInteger(){
        this.rules.push({condition : (v : string) => (!v || parseFloat(v) === parseInt(v)), message : `Valeur entière uniquement`});
        return this;
    }

    public isDate(){
        this.rules.push({condition : (v : string) => (!v || !Number.isNaN(new Date(v).getTime())), message : `Format date uniquement`});
        return this;
    }

    /**
     * Par défaut, allow empty est true
    */
    public isArray(allowEmpty = true){
        this.rules.push({condition:(v : any) => (!v || Array.isArray(v)), message: `Tableau d'élément attendu`});
        if(!allowEmpty) this.rules.push({condition:(v : string) => (!v || v.length > 0), message: `Au moins un élément requis`});
        return this;
    }
}
