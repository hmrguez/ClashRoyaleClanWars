import {DenominationEnum, QualityEnum, TargetEnum} from "./CardEnums";

export interface ICardDto {
  id: number
  name: string
  type: string
  description: string
  elixir: number
  quality: string
  damage: number
  areaDamage: boolean
  target: string
  initialLevel: number
  imageUrl: string
}
