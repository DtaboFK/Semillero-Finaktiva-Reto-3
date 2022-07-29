import { IUsuario } from "./IUsuario";

export class IResponse {
    
    header!: Header;
    data!: IUsuario[];
    // data!: string | string[];

    constructor() {
        this.header = new Header();
    }

}

export class Header {
    code!: number;
    message!: string;
}