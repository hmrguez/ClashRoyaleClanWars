export interface Challenge{
    id: Number,
    name: string,
    description: string,
    cost: Number,
    amountReward: Number,
    startDate: string,
    durationInHours: Number,
    isOpen: boolean,
    minLevel: Number,
    lossLimit: Number
}