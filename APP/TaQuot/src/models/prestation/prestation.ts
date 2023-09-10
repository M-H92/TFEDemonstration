export default class Prestation {
  id = "";
  issueGitLab = 0;
  displayNumber = 0;
  commentaire = "";
  tache = "";
  // date = '' ;
  date = new Date();
  temps = 0;
  typeTache = "";
  commanditaire = "";
  application = "";
  module = "";

  get formatedDate(): string {
    if (this.date == null || this.date == undefined) return ``;

    return `${this.date.getDate()}/${
      this.date.getMonth() + 1
    }/${this.date.getFullYear()}`;
  }
}
