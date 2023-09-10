import PrestationTime from "./prestationTime";

export default class WeeklyRecapDTO {
  user = "";
  times: number[] = [];
}

export class WeeklyRecap extends WeeklyRecapDTO {
  prestations: PrestationTime[] = [];
  constructor(dto: WeeklyRecapDTO) {
    super();
    this.user = dto.user;
    this.times.push(...dto.times);
    this.prestations = this.times.map((t) => new PrestationTime(t));
  }
}
