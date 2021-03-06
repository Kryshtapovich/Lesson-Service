import { AnswerVisualizationModel } from "@Models/Visualization";
import { Box, Card, Typography } from "@mui/material";
import { SxProps } from "@mui/system";
import * as Chart from "recharts";

import {
  card,
  chartWrapper,
  placeholder,
  contentWrapper,
  text,
  tooltip,
  tooltipText
} from "./style";

interface Props {
  answers: Array<AnswerVisualizationModel>;
  sx?: SxProps;
}

function ResultVisualizationCard({ answers, sx }: Props) {
  const style = { ...card, ...sx };

  return (
    <Card sx={style}>
      <Box sx={contentWrapper}>
        {answers.length ? (
          answers.map((a, i) => (
            <Box key={i}>
              <Typography sx={text}>{a.questionText}</Typography>
              <Box sx={chartWrapper}>
                <Chart.ResponsiveContainer minWidth={"100%"} aspect={2.5}>
                  <Chart.BarChart
                    data={a.options}
                    margin={{ left: -15, right: 15 }}
                    barCategoryGap="20%"
                  >
                    <Chart.CartesianGrid />
                    <Chart.XAxis dataKey="optionText" stroke="white" tick={false} />
                    <Chart.YAxis dataKey="answersAmount" stroke="white" allowDecimals={false} />
                    <Chart.Tooltip
                      contentStyle={tooltip}
                      wrapperStyle={tooltipText}
                      itemStyle={tooltipText}
                      formatter={(value: string) => [value, "answers"]}
                    />
                    <Chart.Bar
                      dataKey="answersAmount"
                      radius={[10, 10, 0, 0]}
                      minPointSize={4}
                      barSize={35}
                    >
                      {a.options.map((o, i) => (
                        <Chart.Cell key={`cell-${i}`} fill={o.isCorrect ? "#33e668" : "#c72a2a"} />
                      ))}
                    </Chart.Bar>
                  </Chart.BarChart>
                </Chart.ResponsiveContainer>
              </Box>
            </Box>
          ))
        ) : (
          <Typography sx={placeholder}>
            Survey don't have option questions to show diagrams
          </Typography>
        )}
      </Box>
    </Card>
  );
}

export default ResultVisualizationCard;
