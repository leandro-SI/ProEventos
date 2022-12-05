import { Evento } from '../../models/Evento';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../../services/evento.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  modalRef?: BsModalRef;
  message?: string;

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public widthImg: number = 150;
  public marginImg: number = 2;
  public exibirImagem: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.spinner.show();
    this.getEventos()
  }

  public getEventos(): void {

    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = eventos;
      },
      error: (error: string) => {
        this.spinner.hide();
        this.showError('Erro ao carregar os eventos.', 'Erro!')
      },
      complete: () => {
        this.spinner.hide();
      }
    })

  }

  public alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.message = 'Confirmed!';
    this.modalRef?.hide();
    this.showSuccess('O evento foi deletado com sucesso.', 'Deletado!');
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef?.hide();
  }

  showSuccess(msg, title) {
    this.toastr.success(msg, title);
  }

  showError(msg, title) {
    this.toastr.error(msg, title);
  }

}
