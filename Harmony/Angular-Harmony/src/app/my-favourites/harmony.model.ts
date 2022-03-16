export interface harmonyCreationDTO{
  firstChord: string;
  secondChord: string;
  thirdChord: string;
  fourthChord: string;
  fifthChord: string;
  sixthChord: string;
  seventhChord: string;
  eigthChord: string;
  numberOfChords: number;
  key: string;
  isMagic: boolean;
}

export interface harmonyDTO{
  id: number;
  userId: string;
  firstChord: string;
  secondChord: string;
  thirdChord: string;
  fourthChord: string;
  fifthChord: string;
  sixthChord: string;
  seventhChord: string;
  eigthChord: string;
  numberOfChords: number;
  key: string;
  isMagic: boolean;
}

export class harmonyVM {

  id: number;
  numberOfChords: number;
  key: string;
  isMagic: boolean;
  chords: string[];

  constructor(harmony:harmonyDTO) {
    this.id = harmony.id;
    this.numberOfChords = harmony.numberOfChords;
    this.key = harmony.key;
    this.isMagic = harmony.isMagic;
    this.chords = [harmony.firstChord, harmony.secondChord, harmony.thirdChord,harmony.fourthChord,harmony.fifthChord,harmony.sixthChord,harmony.seventhChord,harmony.eigthChord]

    this.chords = this.chords.filter( n => n!= null);
  }

}


export class GuitarChord {
  key: string;
  positions: string;
  fingers: string;
  variation: number;

  constructor(key:string, positions:string, fingers:string, variation:number){
    this.key =key;
    this.positions=positions;
    this.fingers = fingers;
    this.variation = variation;
  }
};

export class GuitarHarmony{
  id:number;
  harmonies: GuitarChord[] = [];

  constructor(id:number){this.id = id}

  addHarmony(guitarChord:GuitarChord){
    this.harmonies.push(guitarChord);
  }
}
