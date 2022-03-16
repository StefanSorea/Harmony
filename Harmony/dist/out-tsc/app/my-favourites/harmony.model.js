export class harmonyVM {
    constructor(harmony) {
        this.id = harmony.id;
        this.numberOfChords = harmony.numberOfChords;
        this.key = harmony.key;
        this.isMagic = harmony.isMagic;
        this.chords = [harmony.firstChord, harmony.secondChord, harmony.thirdChord, harmony.fourthChord, harmony.fifthChord, harmony.sixthChord, harmony.seventhChord, harmony.eigthChord];
        this.chords = this.chords.filter(n => n != null);
    }
}
//# sourceMappingURL=harmony.model.js.map