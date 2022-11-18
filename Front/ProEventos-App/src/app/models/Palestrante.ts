import { PalestranteEvento } from "./PalestranteEvento";
import { RedeSocial } from "./RedeSocial";


export interface Palestrante {
  id: number,
  nome: string,
  miniCurriculo: string,
  imageURL: string,
  telefone: string,
  email: string,
  redesSociais: RedeSocial[],
  palestrantesEventos: PalestranteEvento[]
}
