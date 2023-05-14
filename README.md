# Video Service

Video service is responsible to handle video

## API Endpoints
1. [Post](#post)
    1. [Create Post](#create-post)

### Post

#### Create Post
```js
POST /api/posts
```

##### Sample request object
```json
{
    title: "Sample title",
    description: "Sample video descriptions",
    tags: ["technology", "trending"],
    videoKey: "55946ee5-8968-40e7-94ef-5639195328de"
}
```

##### Sample response object
```json
{
    success: true,
    messages: [],
    data: {
        id: "93bd4683-3023-4f33-9ddf-e0572841ad4f"
        title: "Sample title",
        description: "Sample video descriptions",
        tags: ["technology", "trending"],
        videoKey: "55946ee5-8968-40e7-94ef-5639195328de",
        videoId: "KVO9yy1oO5j"
        createdOn: "2023-05-01 12:02:33 T00:00"
    }
}
```