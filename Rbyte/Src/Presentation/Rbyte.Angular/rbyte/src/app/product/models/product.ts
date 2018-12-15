export class Product {
    constructor(productId: number, name: string,
        description: string, barcode: number,
        tax: number, priceWithoutMargin: number,
        fullPrice: number) {
        this.productId = productId;
        this.name = name;
        this.description = description;
        this.barcode = barcode;
        this.tax = tax;
        this.priceWithoutMargin = priceWithoutMargin;
        this.fullPrice = fullPrice;
    }
    productId: number;
    name: string;
    description: string;
    barcode: number;
    tax: number;
    priceWithoutMargin: number;
    fullPrice: number;
}
