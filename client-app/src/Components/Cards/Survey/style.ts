import { SxProps } from "@mui/system";

export const card: SxProps = {
  width: "fit-content",
  boxShadow: 10,
  borderRadius: 3
};

export const id: SxProps = {
  fontSize: 14,
  color: "whitesmoke"
};

export const status: SxProps = {
  mb: 1.5,
  color: "whitesmoke"
};

export const title: SxProps = {
  fontSize: 18,
  fontWeight: 500,
  color: "white"
};

export const date: SxProps = {
  fontSize: 17,
  fontWeight: 500,
  color: "white"
};

export const close: SxProps = {
  transition: "0.4s",
  color: "yellow"
};

export const details: SxProps = {
  transition: "0.4s",
  color: "turquoise",
  "&:hover": {
    background: "rgba(64, 224, 208, 0.1)"
  }
};

export const results: SxProps = {
  transition: "0.4s",
  color: "#1af27f",
  "&:hover": {
    background: "rgba(16, 242, 127, 0.1)"
  }
};

export const remove: SxProps = {
  transition: "0.4s",
  color: "red",
  "&:hover": {
    background: "rgba(255, 0, 0, 0.1)"
  }
};
