export class Usuario {

    /*IdUsuario : number = 0;
    Nombre : string = '';
    Apellido : string = '';
    FechaNacimiento : Date = new Date();
    IdTipoDoc : number = 0;
    Documento : string = '';
    Contacto : string = '';
    Correo : string = '';
    Direccion : string = '';*/
    
    private _IdUsuario : number = 0;
    public get IdUsuario() : number {
        return this._IdUsuario;
    }
    public set IdUsuario(v : number) {
        this._IdUsuario = v;
    }
    
    private _Nombre : string = '';
    public get Nombre() : string {
        return this._Nombre;
    }
    public set Nombre(v : string) {
        this._Nombre = v;
    }
    
    private _Apellido : string = '';
    public get Apellido() : string {
        return this._Apellido;
    }
    public set Apellido(v : string) {
        this._Apellido = v;
    }
    
    private _FechaNacimiento : Date = new Date();
    public get FechaNacimiento() : Date {
        return this._FechaNacimiento;
    }
    public set FechaNacimiento(v : Date) {
        this._FechaNacimiento = v;
    }
    
    private _IdTipoDoc : number = 0;
    public get IdTipoDoc() : number {
        return this._IdTipoDoc;
    }
    public set IdTipoDoc(v : number) {
        this._IdTipoDoc = v;
    }
    
    private _Documento : string = '';
    public get Documento() : string {
        return this._Documento;
    }
    public set Documento(v : string) {
        this._Documento = v;
    }
    
    private _Contacto : string = '';
    public get Contacto() : string {
        return this._Contacto;
    }
    public set Contacto(v : string) {
        this._Contacto = v;
    }
    
    private _Correo : string = '';
    public get Correo() : string {
        return this._Correo;
    }
    public set Correo(v : string) {
        this._Correo = v;
    }
    
    private _Direccion : string = '';
    public get Direccion() : string {
        return this._Direccion;
    }
    public set Direccion(v : string) {
        this._Direccion = v;
    }

    
}