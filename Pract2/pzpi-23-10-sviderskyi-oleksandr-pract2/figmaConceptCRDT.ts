// Спрощений приклад структури об'єкта з LWW (Last Write Wins) елементом
interface VectorNode {
    id: string;
    properties: {
        x: { value: number, timestamp: number };
        y: { value: number, timestamp: number };
    };
}

// Функція злиття змін від різних користувачів
function mergeChanges(local: VectorNode, remote: VectorNode): VectorNode {
    return {
        id: local.id,
        properties: {
            x: remote.properties.x.timestamp > local.properties.x.timestamp 
               ? remote.properties.x : local.properties.x,
            y: remote.properties.y.timestamp > local.properties.y.timestamp 
               ? remote.properties.y : local.properties.y
        }
    };
}
