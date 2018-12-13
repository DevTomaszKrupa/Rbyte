export class SideNavItem {
    name: string;
    order: number;
    link: string;

    constructor(name: string,
        order: number,
        link: string) {

        this.name = name;
        this.order = order;
        this.link = link;
    }
}