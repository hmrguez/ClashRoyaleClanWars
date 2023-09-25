export interface ICardDto {
  Id: number
  Name: string
  Type: DenominationEnum
  Description: string
  Elixir: number
  Quality: QualityEnum
  Damage: number
  AreaDamage: boolean
  Target: TargetEnum
  InitialLevel: number
  ImageUrl: string
}
