--
-- PostgreSQL database dump
--

-- Dumped from database version 14.3
-- Dumped by pg_dump version 14.3

-- Started on 2022-05-15 13:50:50

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

DROP DATABASE lupit;
--
-- TOC entry 3323 (class 1262 OID 16394)
-- Name: lupit; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE lupit WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Portuguese_Brazil.1252';


ALTER DATABASE lupit OWNER TO postgres;

\connect lupit

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
-- TOC entry 212 (class 1259 OID 24599)
-- Name: jogadores; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.jogadores (
    id integer NOT NULL,
    name text NOT NULL,
    age bigint NOT NULL,
    time_id bigint,
    created_at date NOT NULL,
    updated_at date NOT NULL
);


ALTER TABLE public.jogadores OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 24598)
-- Name: jogadores_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."jogadores_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."jogadores_Id_seq" OWNER TO postgres;

--
-- TOC entry 3324 (class 0 OID 0)
-- Dependencies: 211
-- Name: jogadores_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."jogadores_Id_seq" OWNED BY public.jogadores.id;


--
-- TOC entry 210 (class 1259 OID 24590)
-- Name: times; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.times (
    id integer NOT NULL,
    name text NOT NULL,
    updated_at date NOT NULL,
    created_at date NOT NULL
);


ALTER TABLE public.times OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 24589)
-- Name: times_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."times_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."times_Id_seq" OWNER TO postgres;

--
-- TOC entry 3325 (class 0 OID 0)
-- Dependencies: 209
-- Name: times_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."times_Id_seq" OWNED BY public.times.id;


--
-- TOC entry 3170 (class 2604 OID 24602)
-- Name: jogadores id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.jogadores ALTER COLUMN id SET DEFAULT nextval('public."jogadores_Id_seq"'::regclass);


--
-- TOC entry 3169 (class 2604 OID 24593)
-- Name: times id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.times ALTER COLUMN id SET DEFAULT nextval('public."times_Id_seq"'::regclass);


--
-- TOC entry 3317 (class 0 OID 24599)
-- Dependencies: 212
-- Data for Name: jogadores; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.jogadores (id, name, age, time_id, created_at, updated_at) VALUES (4, 'Jogador 1', 23, 2, '2022-05-14', '2022-05-15');
INSERT INTO public.jogadores (id, name, age, time_id, created_at, updated_at) VALUES (6, 'Jogador 2', 25, 4, '2022-05-15', '2022-05-15');


--
-- TOC entry 3315 (class 0 OID 24590)
-- Dependencies: 210
-- Data for Name: times; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.times (id, name, updated_at, created_at) VALUES (1, 'Time 1', '2022-05-14', '2022-05-14');
INSERT INTO public.times (id, name, updated_at, created_at) VALUES (2, 'Time 2', '2022-05-14', '2022-05-14');
INSERT INTO public.times (id, name, updated_at, created_at) VALUES (3, 'Time 4', '2022-05-14', '2022-05-14');
INSERT INTO public.times (id, name, updated_at, created_at) VALUES (4, 'Time 5', '2022-05-14', '2022-05-14');


--
-- TOC entry 3326 (class 0 OID 0)
-- Dependencies: 211
-- Name: jogadores_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."jogadores_Id_seq"', 6, true);


--
-- TOC entry 3327 (class 0 OID 0)
-- Dependencies: 209
-- Name: times_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."times_Id_seq"', 4, true);


--
-- TOC entry 3174 (class 2606 OID 24606)
-- Name: jogadores jogadores_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.jogadores
    ADD CONSTRAINT jogadores_pkey PRIMARY KEY (id);


--
-- TOC entry 3172 (class 2606 OID 24597)
-- Name: times times_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.times
    ADD CONSTRAINT times_pkey PRIMARY KEY (id);


-- Completed on 2022-05-15 13:50:51

--
-- PostgreSQL database dump complete
--

