import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { ActorClient } from 'src/app/core/services/actor.client';

@Component({
  selector: 'app-actor-list',
  templateUrl: './actor-list.component.html',
  styleUrls: ['./actor-list.component.css'],
})
export class ActorListComponent {
  actors: any[] | undefined;
  pageSize = 10;
  currentPage = 1;
  totalPages = 0;
  pages: number[] = [];
  constructor(private router: Router, private client: ActorClient) {
    this.getActors();
  }

  async getActors() {
    this.actors = await firstValueFrom(this.client.getActors());

    this.totalPages = Math.ceil(this.actors!.length / this.pageSize);
    this.pages = Array(this.totalPages)
      .fill(0)
      .map((x, i) => i + 1);
  }

  getCurrentPageData(): any[] {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    return this.actors ? this.actors.slice(startIndex, endIndex) : [];
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.pages = this.getPages(this.currentPage, this.totalPages);
    }
  }
  
  getPages(current: number, total: number): number[] {
    const pagesToShow = 7;
    const halfPagesToShow = Math.floor(pagesToShow / 2);
    let pages: number[] = [];
  
    if (total <= pagesToShow) {
      // If the total number of pages is less than or equal to the number of pages to show,
      // simply display all the page numbers
      pages = Array.from({ length: total }, (_, i) => i + 1);
    } else if (current - halfPagesToShow <= 0) {
      // If the current page is near the beginning of the page range,
      // display the first n pages
      pages = Array.from({ length: pagesToShow }, (_, i) => i + 1);
    } else if (current + halfPagesToShow >= total) {
      // If the current page is near the end of the page range,
      // display the last n pages
      pages = Array.from({ length: pagesToShow }, (_, i) => total - pagesToShow + i + 1);
    } else {
      // Otherwise, display a range of pages that includes the current page
      pages = Array.from({ length: pagesToShow }, (_, i) => current - halfPagesToShow + i);
    }
  
    return pages;
  }

  goToActorDetails(id: any) {
    this.router.navigate(['/actor/detail', id]);
  }
}
