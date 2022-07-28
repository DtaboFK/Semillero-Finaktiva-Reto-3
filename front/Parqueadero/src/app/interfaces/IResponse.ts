export class IResponse {
    Header = new Header;
    Data!: string | string[];
}

export class Header {
    Code!: number;
    Message!: string;
}