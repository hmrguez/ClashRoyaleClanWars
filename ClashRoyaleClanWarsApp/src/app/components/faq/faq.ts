//create an object class that has a title and a body

export class FAQ {
  title: string;
  body: string;
  id:number;
  constructor(id:number, title:string, body:string) {
    this.title = title;
    this.body = body;
    this.id = id;
  }
}