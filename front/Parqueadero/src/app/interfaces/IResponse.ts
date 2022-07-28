export class IResponse {
    
    header!: Header;
    data!: string | string[];

    constructor() {
        this.header = new Header();
    }

}

export class Header {
    code!: number;
    message!: string;
}