package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class CreateWorkflowTemplateExample
{
    fun createWorkflowTemplate()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val stages1Action = ActionInput()
        )

        val stages1Conditions1 = ConditionInput(
            scheduleKind = "relative",
            waitDuration = 2,
            waitDurationUnit = "calendarDay",
            kind = "schedule",
        )

        val stages1Conditions = arrayListOf<ConditionInput>(
            stages1Conditions1,
        )

        val stages1 = StageInput(
            name = "10% rollout on day 1",
            executeConditionsInSequence = true,
            action = stages1Action,
            conditions = stages1Conditions,
        )

        val stages = arrayListOf<StageInput>(
            stages1,
        )

        val createWorkflowTemplateInput = CreateWorkflowTemplateInput(
            key = null,
            name = null,
            description = null,
            workflowId = null,
            projectKey = null,
            environmentKey = null,
            flagKey = null,
            stages = stages,
        )

        try
        {
            val response = WorkflowTemplatesApi().createWorkflowTemplate(
                createWorkflowTemplateInput = createWorkflowTemplateInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling WorkflowTemplatesApi#createWorkflowTemplate")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling WorkflowTemplatesApi#createWorkflowTemplate")
            e.printStackTrace()
        }
    }
}
