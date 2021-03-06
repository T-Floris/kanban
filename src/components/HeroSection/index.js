import React, { useState } from "react";
import Video from "../../videos/video.mp4";
import { ButtonTransparent } from "../ButtonElements";
import {
  HeroContainer,
  HeroBackground,
  VideoBackground,
  HeroContent,
  HeroH1,
  HeroP,
  HeroBtnWrapper,
  ArrowForward,
  ArrowRight,
} from "./HeroElements";

const HeroSection = () => {
  const [hover, setHover] = useState(false);

  const onHover = () => {
    setHover(!hover);
  };

  return (
    <HeroContainer id="home">
      <HeroBackground>
        <VideoBackground autoPlay loop muted src={Video} type="video/mp4" />
      </HeroBackground>
      <HeroContent>
        <HeroH1>Kanban</HeroH1>
        <HeroP>Kanban helps teams work better.</HeroP>
        <HeroBtnWrapper>
          <ButtonTransparent
            to='/signin'
            onMouseEnter={onHover}
            onMouseLeave={onHover}
            primary="true"
            dark="true"
          >
            Get started {hover ? <ArrowForward /> : <ArrowRight />}
          </ButtonTransparent>
        </HeroBtnWrapper>
      </HeroContent>
    </HeroContainer>
  );
};

export default HeroSection;
