export default class PrestationTime{
    
    constructor(time : number){
        time >= 0 ? this.time = time : 0;
    }

    public time = 0;
    public getTime() {return this.time === 0 ? 'NA' : this.time.toString();}
    public getColor(){
        if(this.time < 480-120)
            return 'error'
        if(this.time < 480-60)
            return 'warning'
        if(this.time < 480+60)
            return 'success'
        if(this.time < 480+120)
            return 'warning'
        return 'error'
    }
    public getPercent(){
        return (this.time / 480) * 100; 
    }
}