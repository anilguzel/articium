vcl 4.0;

backend review {
    .host = "review-api"; 
    .port = "8083";       
}

backend article {
    .host = "article-api";  
    .port = "8082";        
}

sub vcl_recv {
    if (req.http.method == "GET") {
        if (req.url ~ "^/api/review") {
            set req.backend = review;
        } else if (req.url ~ "^/api/article") {
            set req.backend = article;
        }
    }

    if (req.method == "PURGE") {
        if (req.url ~ "^/[^&]+") {
            set id = regsub(req.url, "\([^&]+)", "\1");
            ban(req.http.hash_url);
        }
    }
}

sub vcl_backend_fetch {
    if (req.backend.cache) {
        return (hit);
    }

    req.backend = req.backend;
    req.url = req.url;
    req.request = "GET";
}

sub vcl_backend_response {
    if (!req.backend.cache) {
        set req.backend.cache_ttl = 600;
        set req.backend.grace_period = 10;
    }

    return (deliver);
}