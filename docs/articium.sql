--
-- PostgreSQL database dump
--

-- Dumped from database version 14.4 (Debian 14.4-1.pgdg110+1)
-- Dumped by pg_dump version 14.4

-- Started on 2024-04-21 10:29:39 UTC

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 209 (class 1259 OID 16385)
-- Name: Articles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Articles" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "Author" text NOT NULL,
    "ArticleContent" text NOT NULL,
    "PublishDate" timestamp with time zone NOT NULL,
    "StarCount" integer NOT NULL
);


ALTER TABLE public."Articles" OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 16392)
-- Name: Reviews; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Reviews" (
    "Id" uuid NOT NULL,
    "ArticleId" uuid NOT NULL,
    "Reviewer" text NOT NULL,
    "ReviewContent" text NOT NULL
);


ALTER TABLE public."Reviews" OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 16399)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "UserName" text NOT NULL,
    "Role" text NOT NULL
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 3319 (class 0 OID 16385)
-- Dependencies: 209
-- Data for Name: Articles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Articles" ("Id", "Title", "Author", "ArticleContent", "PublishDate", "StarCount") FROM stdin;
\.


--
-- TOC entry 3320 (class 0 OID 16392)
-- Dependencies: 210
-- Data for Name: Reviews; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Reviews" ("Id", "ArticleId", "Reviewer", "ReviewContent") FROM stdin;
850401d8-4f02-4815-b413-ace78d1e15f8	3fa85f64-5717-4562-b3fc-2c963f66afa6	string	string
311df495-7eae-407c-84a2-beefe10676a1	3fa85f64-5717-4562-b3fc-2c963f66afa6	string	string
de242db0-1a6f-4609-a080-8de653b07140	3fa85f64-5717-4562-b3fc-2c963f66afa6	string	string
6d9271fb-07d2-48c6-ab24-b6820388530f	3fa85f64-5717-4562-b3fc-2c963f66afa6	string	string
\.


--
-- TOC entry 3321 (class 0 OID 16399)
-- Dependencies: 211
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("Id", "UserName", "Role") FROM stdin;
\.


--
-- TOC entry 3175 (class 2606 OID 16391)
-- Name: Articles PK_Articles; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Articles"
    ADD CONSTRAINT "PK_Articles" PRIMARY KEY ("Id");


--
-- TOC entry 3177 (class 2606 OID 16398)
-- Name: Reviews PK_Reviews; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reviews"
    ADD CONSTRAINT "PK_Reviews" PRIMARY KEY ("Id");


--
-- TOC entry 3179 (class 2606 OID 16405)
-- Name: Users PK_Users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");


-- Completed on 2024-04-21 10:29:39 UTC

--
-- PostgreSQL database dump complete
--

