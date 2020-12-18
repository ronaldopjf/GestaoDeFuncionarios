import { MatPaginatorIntl } from '@angular/material/paginator';

export function getBrazilianPaginatorIntl() {
    const paginatorIntl = new MatPaginatorIntl();

    paginatorIntl.itemsPerPageLabel = 'Itens por página';
    paginatorIntl.firstPageLabel = 'Primeira página';
    paginatorIntl.previousPageLabel = 'Página anterior';
    paginatorIntl.nextPageLabel = 'Próxima página';
    paginatorIntl.lastPageLabel = 'Última página';

    return paginatorIntl;
}